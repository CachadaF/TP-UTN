#!/usr/bin/perl
use strict;
use Bio::DB::GenBank;
use Bio::SearchIO;
use Bio::SeqIO;
use Bio::Seq;

my $blast_input_path = $ARGV[0];
if (!defined($blast_input_path)) 
{
  print "Especifique archivo blast.out";
  exit 1;
}

my $pattern = $ARGV[1];
if (!defined($pattern)) 
{
  print "Especifique un patron.";
  exit 1;
} 

my $geneBank_factory = Bio::DB::GenBank->new();

my $directorio = './output_ex3';

my $input_blast = new Bio::SearchIO(-format => "blast", -file => $blast_input_path);

while(my $result = $input_blast->next_result) 
{
  while(my $hit = $result->next_hit) 
  {
    while(my $hsp = $hit->next_hsp) 
    {
      
      if ($hit->description =~ m/$pattern/) 
      {
		  my $accession = $hit->accession;

		  my $secuencia = $geneBank_factory->get_Seq_by_acc($accession);
		  
		  my $output_file_fasta_ex3 = Bio::SeqIO->new(-file => ">./" . $directorio . "/" . $accession . ".fas", -format => "fasta");

		  $output_file_fasta_ex3 -> write_seq($secuencia);

		  my $hitRecord = "\n    " . $result->query_name . "  Hit: " . $hit->name .
			"   Longitud del Hit: " . $hsp->length("total") .
			"   Porcentaje de identidad: " . $hsp->percent_identity;				

		  print $hitRecord;
      }
      
    }
  }
}

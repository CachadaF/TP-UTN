#!/usr/bin/perl

use Bio::SeqIO;
use Bio::Tools::Run::StandAloneBlastPlus;
use strict;

my $file = shift;

my $input_fasta  = Bio::SeqIO->new(-format => 'fasta', 
								-file => $file);


my $output_blast_file = './blast_local.out';

#Hay que instalar el blastdb en /var/lib/blastdb/swissprot y luego hacerle formatdb -i swisprot

my $fac_local = Bio::Tools::Run::StandAloneBlastPlus->new(-program => 'blastn', 
														-db_name => 'swissprot');
while (my $sequence_obj = $input_fasta->next_seq) {
  
   $fac_local->blastp(
     -query => $sequence_obj,
     -outfile => $output_blast_file,
  );     
  
}


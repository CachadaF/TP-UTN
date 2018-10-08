#!/usr/bin/perl

use Bio::SeqIO;
use Bio::Tools::Run::StandAloneBlastPlus;
use strict;

my $file = shift;

my $input_fasta  = Bio::SeqIO->new(-format => 'fasta', 
								-file => $file);


my $output_blast_file = './blast_remote.out';

my $fac_remote = Bio::Tools::Run::StandAloneBlastPlus->new(
  -db_name => "swissprot",
  -remote => 1
);

while (my $sequence_obj = $input_fasta->next_seq) {
  
   $fac_remote->blastp(
     -query => $sequence_obj,
     -outfile => $output_blast_file,
  );     
  
}

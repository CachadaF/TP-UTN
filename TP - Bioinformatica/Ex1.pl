#!/usr/bin/perl

use strict;
use Bio::SeqIO;
use Bio::SeqUtils;

my $file = shift;

my $input_genbank  = Bio::SeqIO->new(-format => 'genbank', 
								-file => $file);

my $output_fasta = Bio::SeqIO->new(-format => 'fasta', 
								-file  => '>./ex1_output_fasta.fas');

open my $fh, '>', "ex1_output_6_frames.txt" or die "Cannot open output.txt: $!";

# Translate de todas las secuencias.

print "Trascripcion de la secuencia -> ex1_output_fasta.fas ", "\t","\n";

print "Trascripcion de los 6 frames -> ex1_output_6_frames.txt ", "\t","\n";

while( my $sequence = $input_genbank->next_seq ) {
	
	#Primero guardo la secuencia en el fasta (La mas larga que es la correcta).
	
	my $seq_prot_obj = $sequence->translate(-orf => 'longest', start => 'atg');
	
	$output_fasta -> write_seq($seq_prot_obj);
	
	#Luego guardo los 6 frames en un txt.
	
	my @prots = Bio::SeqUtils->translate_6frames($sequence);	

	foreach (@prots)
	{
		print $fh "$_\n"; 
	}						
	
  }

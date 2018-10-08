#!/usr/bin/perl

use strict;
use Bio::SeqIO;
use Bio::Factory::EMBOSS;

my $file = shift;

my $f = Bio::Factory::EMBOSS -> new();

my $input_genbank  = Bio::SeqIO->new(-format => 'genbank', 
								-file => $file);

my $sequence = $input_genbank->next_seq;

my $output_ORF = "./ex4_output_orf.txt";
my $output_Patmatmotifs = "./ex4_output_EMBOSS.txt";

# ORF -> Uso getorf de EMBOSS.
my $get_orf_emboss = $f->program('getorf');

$get_orf_emboss -> run ({-sequence => $sequence,
						  -outseq => $output_ORF});

# PROSITE -> Carga de la Database
#system("sudo prosextract ./prosite");

#Ejecuto el analisis de dominios de las secuencias de aa - El comando salio de lo que usa en EMBOSS para ejecutarlo por consola
system("patmatmotifs  -sequence $file -outfile $output_Patmatmotifs -sformat1 genbank -sprotein1 -nofull -prune -rformat dbmotif -auto");

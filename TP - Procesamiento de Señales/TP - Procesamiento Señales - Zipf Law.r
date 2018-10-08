#TP Procesamiento de Señales
#Ley de ZipF
#http://www.wordcount.org/main.php -> Las palabras mas usadas en ingles
print("TP - Procesamiento de Señales")
library(ggplot2)
library(stringr)
fileName <- '/home/fede/Escritorio/TalesofShakespearebyCharlesandMaryLamb'
fileText <- readChar(fileName, file.info(fileName)$size)
# El fixed con el TRUE es para que cuente si tienen mayusculas en algun lado.
# Le puse un espacio para que solo cuente las palabras esas, sino cuenta las que estan en medio de otras
count_the <- str_count(fileText, pattern = fixed(" the ",TRUE)) 
count_of <- str_count(fileText, pattern = fixed(" of ",TRUE))
count_and <- str_count(fileText, pattern = fixed(" and ",TRUE))
count_to <- str_count(fileText, pattern = fixed(" to ",TRUE))
count_a <- str_count(fileText, pattern = fixed(" a ",TRUE))
count_in <- str_count(fileText, pattern = fixed(" in ",TRUE))
count_that <- str_count(fileText, pattern = fixed(" that ",TRUE))
count_it <- str_count(fileText, pattern = fixed(" it ",TRUE))
count_is <- str_count(fileText, pattern = fixed(" is ",TRUE))
count_was <- str_count(fileText, pattern = fixed(" was ",TRUE))
count_i <- str_count(fileText, pattern = fixed(" i ",TRUE))
count_for <- str_count(fileText, pattern = fixed(" for ",TRUE))
count_on <- str_count(fileText, pattern = fixed(" on ",TRUE))
count_you <- str_count(fileText, pattern = fixed(" you ",TRUE))
count_he <- str_count(fileText, pattern = fixed(" he ",TRUE))
# Listas - tablas
Palabra <- c("the","of","and","to","a","in","that","it","is","was","i","for","on","you","he")

Frecuencia <- c(count_the,count_of,count_and,count_to,count_a,count_in,count_that,count_it,count_is,count_was,count_i,count_for,count_on,count_you,count_he)
Df_Mostrar <- data.frame(Palabra,Frecuencia)
Df_Mostrar$Palabra <- factor(Df_Mostrar$Palabra, levels = Df_Mostrar$Palabra[order(-Df_Mostrar$Frecuencia)])
# Grafico de como se repiten
ggplot(Df_Mostrar, aes( Palabra, Frecuencia)) + ggtitle("Ley de Zipf") + theme(axis.text.x=element_text(angle=45, hjust=1))  + geom_bar(stat = "identity")

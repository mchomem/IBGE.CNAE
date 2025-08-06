# IBGE.CNAE

Example of using minimal api to extract CNAE data from an excel file available at [IBGE CONCLA](https://concla.ibge.gov.br/classificacoes/download-concla.html), file "CNAE_Subclasses_2_3_Estrutura_Detalhada.xlsx".

As shown in the image below, the cells in red represent the content that is read to create the list. The Excel file must hold exactly the same

![excel-read-cells](/Docs/Images/excel-read-cells.png)

## How to use

1. Download the Excel file from [IBGE CONCLA](https://concla.ibge.gov.br/classificacoes/download-concla.html), file "CNAE_Subclasses_2_3_Estrutura_Detalhada.xlsx".
2. Place the file in a folder named `Data` in the root of your project.
3. Build and run the project.
4. The program will read the Excel file and create a list of CNAE objects.
5. Json output exemple:

```json
 [
  {
    "secao": "A",
    "divisao": "01",
    "grupo": "011",
    "classe": "0111-3",
    "subclasse": "0111301",
    "descricao": "Cultivo de arroz"
  },
  {
    "secao": "A",
    "divisao": "01",
    "grupo": "011",
    "classe": "0111-3",
    "subclasse": "0111302",
    "descricao": "Cultivo de milho"
  },
  {
    "secao": "A",
    "divisao": "01",
    "grupo": "011",
    "classe": "0111-3",
    "subclasse": "0111303",
    "descricao": "Cultivo de trigo"
  },
  ...
  ]

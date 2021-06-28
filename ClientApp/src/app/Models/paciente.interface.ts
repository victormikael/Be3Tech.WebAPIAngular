export interface IPaciente
{
    id: number;
    prontuario: string;
    nome: string;
    sobrenome: string;
    dataNascimento: Date;
    genero: string;
    cpf: string;
    rg: string;
    ufRG: string;
    email: string;
    celular: string;
    telefone: string;
    convenio: string;
    carteira: string;
    carteiraValidade: Date;
}
import { Component, OnInit } from "@angular/core";
import { PacienteService } from "../Services/paciente.service";
import { IPaciente } from "../Models/paciente.interface";
import { IConvenio } from "../Models/convenio.interface";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { DatePipe } from "@angular/common";

@Component({
    selector: 'app-paciente',
    templateUrl: './paciente.component.html'
})
export class PacienteComponent implements OnInit {

    public title: string = "Cadastro Paciente";
    
    // Formulario
    public formLabel: string;
    public buttonLabel: string;
    public form!: FormGroup;

    // Obejetos
    public pacientes: IPaciente[] = [];
    public paciente: IPaciente = <IPaciente>{};
    public convenios: IConvenio[] = [];

    private isEditMode: boolean = false;

    public UFS: string[] = ["AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO"];

    constructor(private service: PacienteService, private formBuilder: FormBuilder) {

        this.formLabel = "Cadastrar Paciente";
        this.buttonLabel = "Cadastrar";
    }

    private GetAll(): void {
        this.service.GetAll().subscribe(data =>
            this.pacientes = data,
            error => console.log(error)
        );
    }

    private GetAllConvenio(): void {
        this.service.GetAllConvenio().subscribe(data =>
            this.convenios = data,
            error => console.log(error)
        );
    }

    public onSubmit(): void {
        this.paciente.nome = this.form.controls["nome"].value;
        this.paciente.sobrenome = this.form.controls["sobrenome"].value;
        this.paciente.prontuario = this.form.controls["prontuario"].value;
        this.paciente.dataNascimento = this.form.controls["dataNascimento"].value;
        this.paciente.genero = this.form.controls["genero"].value;
        this.paciente.cpf = this.form.controls["cpf"].value;
        this.paciente.rg = this.form.controls["rg"].value;
        this.paciente.rg = this.form.controls["ufRG"].value;
        this.paciente.email = this.form.controls["email"].value;
        this.paciente.celular = this.form.controls["celular"].value;
        this.paciente.telefone = this.form.controls["telefone"].value;
        this.paciente.convenio = this.form.controls["convenio"].value;
        this.paciente.carteira = this.form.controls["carteira"].value;
        this.paciente.carteiraValidade = this.form.controls["carteiraValidade"].value;

        if (this.isEditMode) {
            this.service.Update(this.paciente).subscribe(() =>
                {
                    this.form.reset();
                    alert("Paciente Atualizado!");
                    this.cancel();
                    this.GetAll();
                }
            )
        }
        else {
            this.service.Create(this.paciente).subscribe(() =>
                {
                    this.form.reset();
                    alert("Paciente Cadastrado!");
                    this.GetAll();
                }
            )
        }

    }
    public cancel(): void {
        this.isEditMode = false;
        this.formLabel = "Cadastrar Paciente";
        this.buttonLabel = "Cadastrar";
        this.paciente = <IPaciente>{};
        this.form.reset();
    }
    public edit(paciente: IPaciente): void {

        this.isEditMode = true;
        this.formLabel = "Atualizar Paciente";
        this.buttonLabel = "Atualizar";
        this.paciente = paciente;
        this.createForm(paciente);
    }

    private createForm(paciente: IPaciente): void {
        let date = new DatePipe(navigator.language);
        const format = "y-MM-dd";
        let dataNascimento = date.transform(paciente.dataNascimento, format);
        let carteiraValidade = date.transform(paciente.carteiraValidade, format);

        this.form = this.formBuilder.group({
            "nome": [paciente.nome, Validators.required],
            "sobrenome": [paciente.sobrenome, Validators.required],
            "prontuario": [paciente.prontuario],
            "dataNascimento": [dataNascimento, Validators.required],
            "genero": [paciente.genero, [Validators.required, Validators.maxLength(1), Validators.pattern("M|F")]],
            "cpf": [paciente.cpf],
            "rg": [paciente.rg],
            "ufRG": [paciente.ufRG],
            "email": [paciente.email, [Validators.required, Validators.email]],
            "celular": [paciente.celular, Validators.required],
            "telefone": [paciente.telefone],
            "convenio": [paciente.convenio],
            "carteira": [paciente.carteira],
            "carteiraValidade": [carteiraValidade]
        });
    }

    ngOnInit(): void {
        this.GetAll();
        this.GetAllConvenio();
        this.createForm(<IPaciente>{});
    }
}

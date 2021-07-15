import { Component, OnInit } from "@angular/core";
import { PacienteService } from "../Services/paciente.service";
import { Paciente } from "../Models/paciente.model";
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
    public pacientes: Paciente[] = [];
    public paciente: Paciente = new Paciente;
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

        // Atualizando objeto paciente        
        let arr: any = Object.entries(this.paciente);
        
        for(let i=1; i<arr.length; i++) {
            arr[i][1] = this.form.controls[arr[i][0]].value;
        }
        
        arr = Object.fromEntries(arr);

        this.paciente = arr;

        if (this.isEditMode) {
            this.service.Update(this.paciente).subscribe(() =>
            {
                this.form.reset();
                alert("Paciente Atualizado!");
                this.cancel();
                this.GetAll();
            });
        }
        else {
            this.service.Create(this.paciente).subscribe(() =>
            {
                this.form.reset();
                alert("Paciente Cadastrado!");
                this.cancel();
                this.GetAll();
            });
        }

    }
    public cancel(): void {
        this.isEditMode = false;
        this.formLabel = "Cadastrar Paciente";
        this.buttonLabel = "Cadastrar";
        this.paciente = <Paciente>{};
        this.form.reset();
    }
    public edit(paciente: Paciente): void {
        this.isEditMode = true;
        this.formLabel = "Atualizar Paciente";
        this.buttonLabel = "Atualizar";
        this.paciente.id = paciente.id;
        this.createForm(paciente);
    }

    private createForm(paciente: Paciente): void {
        let date = new DatePipe(navigator.language);
        const FORMAT = "y-MM-dd";
        let dataNascimento = date.transform(paciente.dataNascimento, FORMAT);
        let carteiraValidade = date.transform(paciente.carteiraValidade, FORMAT);

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
        this.createForm(<Paciente>{});
    }
}

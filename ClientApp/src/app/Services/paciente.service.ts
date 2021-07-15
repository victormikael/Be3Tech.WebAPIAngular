import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Paciente } from "../Models/paciente.model";
import { IConvenio } from "../Models/convenio.interface";

const httpOptions = {
    headers: new HttpHeaders({
        "Content-Type": "application/json"
    })
};

@Injectable()
export class PacienteService {
    constructor(private http: HttpClient) {
    }

    //get
    public GetAll(): Observable<Paciente[]> {
        return this.http.get<Paciente[]>("https://localhost:5001/api/paciente", httpOptions);
    }

    public GetByName(name: string): Observable<Paciente[]> {
        return this.http.get<Paciente[]>("https://localhost:5001/api/paciente/search/" + name, httpOptions);
    }

    public GetAllConvenio(): Observable<IConvenio[]> {
        return this.http.get<IConvenio[]>("https://localhost:5001/api/convenio", httpOptions);
    }

    //post
    public Create(paciente: Paciente): Observable<Paciente> {
        return this.http.post<Paciente>("https://localhost:5001/api/paciente", paciente, httpOptions);
    }

    //patch
    public Update(paciente: Paciente): Observable<Paciente> {
        return this.http.patch<Paciente>("https://localhost:5001/api/paciente", paciente, httpOptions);
    }
}
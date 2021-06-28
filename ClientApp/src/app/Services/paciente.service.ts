import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { IPaciente } from "../Models/paciente.interface";
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
    public GetAll(): Observable<IPaciente[]> {
        return this.http.get<IPaciente[]>("https://localhost:5001/api/paciente", httpOptions);
    }

    public GetByName(name: string): Observable<IPaciente[]> {
        return this.http.get<IPaciente[]>("https://localhost:5001/api/paciente/search/" + name, httpOptions);
    }

    public GetAllConvenio(): Observable<IConvenio[]> {
        return this.http.get<IConvenio[]>("https://localhost:5001/api/convenio", httpOptions);
    }

    //post
    public Create(paciente: IPaciente): Observable<IPaciente> {
        return this.http.post<IPaciente>("https://localhost:5001/api/paciente", paciente, httpOptions);
    }

    //patch
    public Update(paciente: IPaciente): Observable<IPaciente> {
        return this.http.patch<IPaciente>("https://localhost:5001/api/paciente", paciente, httpOptions);
    }
}
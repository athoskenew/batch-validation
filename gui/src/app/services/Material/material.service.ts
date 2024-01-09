import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Material } from '../../models/Materials';
import { Response } from '../../models/Response';

@Injectable({
  providedIn: 'root'
})
export class MaterialService {

  private apiUrl = `${environment.ApiUrl}/Material`
  constructor(private http: HttpClient) { }

  GetMaterials() : Observable<Response<Material[]>>{
    return this.http.get<Response<Material[]>>(this.apiUrl);
  }

  CreateMaterial(material: Material) : Observable<Response<Material[]>>{
    return this.http.post<Response<Material[]>>(this.apiUrl, material);
  }

  GetMaterialById(materialId: number) : Observable<Response<Material>>{
    return this.http.get<Response<Material>>(`this.apiUrl/${materialId}`);
  }

  DeleteMaterial(id: number) : Observable<Response<Material[]>>{
    return this.http.delete<Response<Material[]>>(`${this.apiUrl}?id=${id}`);
  }
}

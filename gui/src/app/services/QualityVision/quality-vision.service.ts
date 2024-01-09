import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { QualityVision } from '../../models/QualityVision';
import { Response } from '../../models/Response';

@Injectable({
  providedIn: 'root'
})
export class QualityVisionService {

  private apiUrl = `${environment.ApiUrl}/QualityVision`
  constructor(private http: HttpClient) {}

  GetVision(id: number) : Observable<Response<QualityVision>>{
    return this.http.get<Response<QualityVision>>(`${this.apiUrl}?id=${id}`);
  }

  CreateVision(qualityVision: QualityVision, materialId: number): Observable<Response<QualityVision>>{
    return this.http.post<Response<QualityVision>>(`${this.apiUrl}?materialId=${materialId}`, qualityVision);
  }

  DeleteVision(id: number) : Observable<Response<QualityVision>>{
    return this.http.delete<Response<QualityVision>>(`${this.apiUrl}?materialId=${id}`);
  }

}

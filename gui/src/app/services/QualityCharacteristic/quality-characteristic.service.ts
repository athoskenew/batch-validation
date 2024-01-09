import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { QualityCharacteristic } from '../../models/QualityCharacteristic';
import { Response } from '../../models/Response';

@Injectable({
  providedIn: 'root'
})
export class QualityCharacteristicService {

  private apiUrl = `${environment.ApiUrl}/QualityCharacteristics`
  constructor(private http: HttpClient) { }

  GetCharacteristics(materialId: number) : Observable<Response<QualityCharacteristic[]>>{
    return this.http.get<Response<QualityCharacteristic[]>>(`${this.apiUrl}?id=${materialId}`)
  }

  CreateCharacteristic(qualityCharacteristic: QualityCharacteristic, materialId: number): Observable<Response<QualityCharacteristic[]>>{
    return this.http.post<Response<QualityCharacteristic[]>>(`${this.apiUrl}?materialId=${materialId}`, qualityCharacteristic);
  }

  DeleteCharacteristic(materialId: number, characteristicId: number): Observable<Response<QualityCharacteristic[]>>{
    return this.http.delete<Response<QualityCharacteristic[]>>(`${this.apiUrl}?materialId=${materialId}&characteristicId=${characteristicId}`);
  }
  
  

}

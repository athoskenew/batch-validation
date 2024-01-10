import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Batch } from '../../models/Batch';
import { Response } from '../../models/Response';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BatchService {

  private apiUrl = `${environment.ApiUrl}/Batch`

  constructor(private http: HttpClient) { }

  getBatches() : Observable<Response<Batch[]>>{
    return this.http.get<Response<Batch[]>>(this.apiUrl);
  }

  CreateBatch(batch: Batch, materialId: number) : Observable<Response<Batch[]>>{
    return this.http.post<Response<Batch[]>>(`${this.apiUrl}?materialId=${materialId}`, batch);
  }

  DeleteBatch(batchId: number) : Observable<Response<Batch>>{
    return this.http.delete<Response<Batch>>(`${this.apiUrl}?batchId=${batchId}`);
  }

}

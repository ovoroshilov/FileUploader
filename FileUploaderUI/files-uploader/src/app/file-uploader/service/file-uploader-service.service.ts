import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UploadFileModel } from '../models/uploadFileModel.model';
import { environment } from '../../../environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class FileUploaderServiceService {
   
  constructor(private http: HttpClient) { }

  postFileForm(model: UploadFileModel) : Observable<string>{
    const formData = new FormData();
    formData.append('file', model.file as File, model.file?.name || '');
    formData.append('email', model.email);
    return this.http.post<string>(`${environment.apiUrl}/api/FileUploader`,  formData);
  }
}

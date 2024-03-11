import { Component } from '@angular/core';
import { FileUploaderServiceService } from '../service/file-uploader-service.service';
import { UploadFileModel } from '../models/uploadFileModel.model';
import { FormsModule, NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-file-upload-form',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './file-upload-form.component.html',
  styleUrl: './file-upload-form.component.css'
})
export class FileUploadFormComponent{
  model: UploadFileModel;
  constructor(private service: FileUploaderServiceService, private toastr: ToastrService)
  {
     this.model = {
      file: null,
      email: ''
     }
  }
  onFileSelected(event: any): void {
    this.model.file = event.target.files[0];
  }
  onFormSubmit() : void{
    if (this.model.email && this.model.file != null) {
    this.service.postFileForm(this.model).subscribe({
   next: () =>{
    this.toastr.success(`Check your email ${this.model.email}`)
    this.model = {
      file: null,
      email: ''
     }
   },
   error: (err) =>{
    console.error(err);
    this.toastr.error(`Ooops something went wrong`)
   }
    })
  }else{
    this.toastr.error(`Please fiil all inputs`)
  }
 }
}

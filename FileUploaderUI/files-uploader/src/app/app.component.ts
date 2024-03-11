import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FileUploadFormComponent } from './file-uploader/file-upload-form/file-upload-form.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FileUploadFormComponent], 
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'test-app';
}

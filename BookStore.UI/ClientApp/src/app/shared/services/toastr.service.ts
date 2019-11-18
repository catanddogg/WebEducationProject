import { ToastrService } from 'ngx-toastr';
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
  })

export class NotificationService {
  constructor(private toastr: ToastrService) 
  {
  }

public NotificationInfo(message : string){
      this.toastr.info(message, 'Information');
}

public NotificationError(message : string){
      this.toastr.error(message, 'Error');
}

public NotificationWarning(message : string){
      this.toastr.warning(message, 'Warning');
}

public NotificationSuccess(message : string){
      this.toastr.success(message, 'Success');
}
}
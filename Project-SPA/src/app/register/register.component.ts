import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any = {};
  @Output() cancelRegister = new EventEmitter();
  constructor(private authService: AuthService, private alertify: AlertifyService ) { }
  ngOnInit() {
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

  registiration() {
    this.authService.register(this.model).subscribe(next => {
      this.alertify.success('Registered');
    }, error => {
      this.alertify.error(error);
    });
  }


}

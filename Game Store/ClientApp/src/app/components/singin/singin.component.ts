import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-singin',
  templateUrl: './singin.component.html',
  styleUrls: ['./singin.component.scss']
})
export class SinginComponent implements OnInit {

  myForm: FormGroup;
  user: User = {};

  constructor(private fb: FormBuilder, private userService: UserService) { }

  ngOnInit(): void {
    this.myForm = this.fb.group({
      userName: ['', [Validators.minLength(3), Validators.required]],
      password: ['', [Validators.required]]
    });

    this.myForm.valueChanges.subscribe(console.log);
  }
  onSubmit() {

    this.user.userName = this.myForm.get('userName')?.value;
    this.user.password = this.myForm.get('password')?.value;
    this.userService.signIn(this.user).subscribe((result : User) => this.user = result);
    console.log(this.user.firstName);
  }
}
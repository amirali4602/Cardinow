import { Component , OnInit } from '@angular/core';
import { UserService } from '../../core/services/user.service';
import { UserModel } from '../../models/user.model';
import { UserCardComponent } from '../../shared/components/user-card.component/user-card.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dashboard.component',
  imports: [CommonModule, UserCardComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
  standalone:true
})
export class DashboardComponent implements OnInit  {
   users: UserModel[] = [];
  constructor( private userservice :UserService){}
  ngOnInit(): void {
    this.LoadUsers();
  }
LoadUsers(){
  this.userservice.getUsers().subscribe({
  next:(data) => 
    {
      this.users = data

    },
  error: (err) =>{
     console.error(err)
    }
  }
  )
}

}

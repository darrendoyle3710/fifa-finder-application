import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(private service: SharedService) { }

  UserList: any = [];

  user: any;

  ngOnInit(): void {
    this.refreshUserList();
  }

  refreshUserList() {
    this.service.getPostList().subscribe(data => {
      this.UserList = data;
    });
  }

}

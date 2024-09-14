import { Component, inject, OnInit } from "@angular/core";
import { ThemeService } from "../../services/theme-service";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { LoginService } from "@services/login-service";
import { SessionService } from "@utils/session-util";
import { Router } from "@angular/router";
import { CustomIconService } from "../../common/custom-icons/custom-icon.service";

@Component({
  selector: 'screen-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
  themeService: ThemeService = inject(ThemeService);

  public formLogin: FormGroup;
  public errorLogin: boolean;

  constructor(
    private customIconService: CustomIconService,
    private loginService: LoginService,
    private router: Router,
    private sessionService: SessionService,
    private fb: FormBuilder,
  ) {
    this.customIconService.init();
  }

  ngOnInit(): void {
    console.log('login')
    this.initForm();
  }

  initForm() {
    this.formLogin = this.fb.group({
      user: [null, Validators.required],
      password: [null, Validators.required]
    });
  }

  toggleTheme() {
    this.themeService.updateTheme();
  }

  doLogin(form: any) {
    const dataLogin = {
      userName: form.user,
      passWord: form.password
    }

    this.loginService.doLogin(dataLogin).subscribe(responseLogin => {
      if (responseLogin.codigo === 'Ok') {
        this.sessionService.saveSessionData(responseLogin.usuario);
        this.sessionService.saveSessionToken(responseLogin.usuario.token);

        this.router.navigateByUrl('/home');
      } else {
        this.errorLogin = true;
      }
    });
  }
}
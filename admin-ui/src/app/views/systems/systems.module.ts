import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { ButtonModule, CardModule, FormModule, GridModule } from '@coreui/angular';
import { IconModule } from '@coreui/icons-angular';
import { SystemsRoutingModule } from './systems-routing.module';


@NgModule({
  declarations: [
    // LoginComponent,
    // RegisterComponent,
    // Page404Component,
    // Page500Component
  ],
  imports: [
    CommonModule,
    SystemsRoutingModule,
    CardModule,
    ButtonModule,
    GridModule,
    IconModule,
    FormModule
  ]
})
export class SystemsModule {
}

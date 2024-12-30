import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component'; // Root component
import { MyExportedComponent } from './components/my-exported/my-exported.component'; // Custom component

@NgModule({
    declarations: [
        AppComponent,       // Declare the root component
        MyExportedComponent // Declare your custom component
    ],
    imports: [
        BrowserModule       // Required to run the app in the browser
    ],
    bootstrap: [AppComponent] // Bootstrap the root component
})
export class AppModule { }

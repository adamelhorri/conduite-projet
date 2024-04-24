import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Question } from './models/Question'; // Assurez-vous d'importer le modèle de données approprié

@Injectable({
  providedIn: 'root'
})
export class QuestionService {

  private baseUrl = 'http://localhost:7215/api/Question'; // Remplacez par l'URL de votre backend .NET

  constructor(private http: HttpClient) { }

  getAllQuestions(): Observable<Question[]> {
    console.log("hello")
    return this.http.get<Question[]>(this.baseUrl);

  } 

  createQuestion(question: Question): Observable<Question> {
    return this.http.post<Question>(this.baseUrl, question);
  }

  updateQuestion(question: Question): Observable<Question> {
    const url = `${this.baseUrl}/${question.question_id}`;
    return this.http.put<Question>(url, question);
  }

  deleteQuestion(questionId: number): Observable<void> {
    const url = `${this.baseUrl}/${questionId}`;
    return this.http.delete<void>(url);
  }
  
}

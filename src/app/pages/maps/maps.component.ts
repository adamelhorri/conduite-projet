import { Component } from '@angular/core';

@Component({
  moduleId: module.id,
  selector: 'maps-cmp',
  templateUrl: 'maps.component.html'
})

export class MapsComponent {
  public Questions: any[] = [
    { id: 1, question: "Question 1?" },
    { id: 2, question: "Question 2?" },
    { id: 3, question: "Question 3?" }
  ];
  public currentQuestionIndex: number = 0;
  public showNoMoreQuestionsCard: boolean = false;

  answerQuestion(response: string) {
    // Gérer la réponse à la question actuelle
    console.log('Réponse à la question', this.currentQuestion.id, ':', response);

    // Passer à la prochaine question ou afficher la carte supplémentaire
    if (this.currentQuestionIndex < this.Questions.length - 1) {
      this.currentQuestionIndex++;
    } else {
      // Si toutes les questions ont été répondues, afficher la carte supplémentaire
      this.showNoMoreQuestionsCard = true;
    }
  }

  get currentQuestion() {
    return this.Questions[this.currentQuestionIndex];
  }
}

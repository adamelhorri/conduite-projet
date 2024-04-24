import { Component, OnInit } from '@angular/core';
import { Question } from '../../models/Question';
import { QuestionService } from '../../question.service';

@Component({
    selector: 'icons-cmp',
    moduleId: module.id,
    templateUrl: 'icons.component.html'
})

export class IconsComponent implements OnInit {
    questions: Question[] = [];

    constructor(private questionService: QuestionService) {}

    ngOnInit() {
        this.loadQuestions();
    }

    loadQuestions() {
        this.questionService.getAllQuestions().subscribe(
            (questions: Question[]) => {
                this.questions = questions;
            },
            (error) => {
                console.error('Error loading questions:', error);
            }
        );
    }
}

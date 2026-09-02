# Exam & Question Management System

Full-stack application built with **ASP.NET Core Clean Architecture** and **Angular (Standalone & Zoneless)** supporting multi-language exam questions.

## Project Structure

```text
interview-question-8/
├── ExamAPI/   # ASP.NET Core Web API (Backend)
└── ExamUI/    # Angular Frontend App (Frontend)


Tech Stack
Backend (ExamAPI): ASP.NET Core 8 Web API, Entity Framework Core, SQL Server

Frontend (ExamUI): Angular (Standalone Components, Zoneless Change Detection), @ngx-translate/core

Setup & Running
1. Backend (ExamAPI)
Bash
cd ExamAPI
dotnet restore
dotnet run
Note: Database migrations and seed data will run automatically on application startup.

2. Frontend (ExamUI)
Bash
cd ExamUI
npm install
npm start
Open http://localhost:4200 in your browser.

Features
Dynamic language switching (Thai / English) without page reload.

Auto-seeding database migrations on application start.

Full CRUD operations for questions and answer choices.
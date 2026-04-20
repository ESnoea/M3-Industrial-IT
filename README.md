# M3-Industrial-IT
Répertoire du travail collaboratif sur le module 3


 **todo list structurée** pour votre projet **"Gestion flexible d’un outil de production"**
---

### **📌 TODO LIST – Projet "Gestion flexible chariot"**
*(Délais : MCD → 30.03.2026 | Cahier des charges → 28.04.2026 | Livrables finaux → 16.06.2026)*

---

## **📅 PHASE 1 : ANALYSE & CONCEPTION (Jusqu’au 30.03.2026)**
### **1️⃣ Comprendre le mandat et la problématique**
- [ ] Lire attentivement les documents :
  - `INF-M3 Mandat Application du module Informatique 2026.pdf`
  - `Directives PM-M3.pdf`
  - `INF-M3 PM Travail à effectuer.pdf`
- [ ] Identifier les **acteurs** (responsable commandes, opérateur production, administrateur).
- [ ] Clarifier les **définitions** :
  - Lot (nom, quantité, état, date création).
  - Recette (nom, opérations/pas, date création).
  - Opération (position, temps d’arrêt, quittance manuelle).
- [ ] Noter les **exigences fonctionnelles** :
  - Éditeur de lots/recettes (C#).
  - Traçabilité des lots (historique daté).
  - Gestionnaire de programme journalier (Codesys).
  - Communication PC ↔ Automate (MySQL).

### **2️⃣ Modélisation de la base de données (MCD + Dictionnaire de données)**
- [ ] **Dictionnaire de données** :
  - Lister toutes les tables nécessaires (ex : `Lots`, `Recettes`, `Operations`, `HistoriqueProduction`).
  - Définir les champs pour chaque table (ex : `Lots` → `id_lot (PK)`, `nom_lot`, `quantite`, `etat`, `date_creation`).
  - Préciser les types de données (INT, VARCHAR, DATETIME, ENUM pour les états).
  - Ajouter les contraintes (UNIQUE, NOT NULL, clés étrangères).
- [ ] **MCD (Modèle Conceptuel de Données)** :
  - Utiliser un outil comme [Lucidchart](https://www.lucidchart.com/), [Draw.io](https://draw.io/), ou [MySQL Workbench](https://www.mysql.com/products/workbench/).
  - Représenter les entités (`Lot`, `Recette`, `Operation`, `Historique`) et leurs relations (1:N, N:M).
  - Exemple de relation :
    - `Recette` (1) → `Operation` (N).
    - `Lot` (1) → `Recette` (1).
    - `Lot` (1) → `HistoriqueProduction` (N).
- [ ] **Vérifier la cohérence** :
  - Un lot peut-il avoir plusieurs recettes ? (Non, d’après le mandat).
  - Une recette peut-elle avoir plusieurs opérations ? (Oui, 1 à 10).
  - L’historique doit-il stocker les événements par pièce ou par lot ? (Les deux, d’après l’exemple).

➡ **Délai** : **Lundi 30.03.2026 à 08h25** (remise du MCD).

---

## **📅 PHASE 2 : CAHIER DES CHARGES & MAQUETTAGE (Jusqu’au 28.04.2026)**
### **3️⃣ Cahier des charges orienté client**
- [ ] **Structure du document** :
  - Page de garde (titre, date, auteurs, version).
  - Sommaire.
  - Introduction (contexte, objectifs).
  - **Description fonctionnelle** :
    - **Partie PC (C#)** :
      - Éditeur de lots (création/modification/suppression).
      - Éditeur de recettes (ajout d’opérations, temps d’arrêt, quittance).
      - Système de traçabilité (affichage historique, filtres par lot/date).
    - **Partie Automate (Codesys)** :
      - Lecture des lots depuis la BDD.
      - Lancement de la production (début/fin de lot, pièces, alarmes).
      - Envoi d’événements vers la BDD (traçabilité).
  - **Exigences non fonctionnelles** :
    - Performance (temps de réponse < 2s pour les requêtes).
    - Sécurité (accès utilisateur, sauvegardes BDD).
    - Compatibilité (Windows 10+, MySQL 8.0).
  - **Contraintes techniques** :
    - Langages : C# (Windows Forms), Codesys (pour l’automate).
    - Base de données : MySQL.
    - Communication : Requêtes SQL depuis C# et Codesys.
  - **Annexes** :
    - Schéma de la BDD (MCD).
    - Maquettes des interfaces (voir point 4).

### **4️⃣ Maquettage des interfaces HMI**
#### **🖥 Partie PC (C# – Windows Forms)**
- [ ] **Éditeur de lots** :
  - Maquette avec :
    - Liste des lots existants (DataGridView).
    - Boutons "Nouveau", "Modifier", "Supprimer".
    - Formulaire de création/modification (champs : nom, quantité, recette, état).
    - Validation des données (ex : quantité > 0).
  - Exemple de wireframe :
    ![Maquette Éditeur de lots](https://via.placeholder.com/600x400?text=Maquette+Éditeur+de+lots)
- [ ] **Éditeur de recettes** :
  - Liste des recettes existantes.
  - Boutons "Nouveau", "Modifier".
  - Formulaire avec :
    - Nom de la recette.
    - Liste des opérations (position, temps d’arrêt, quittance manuelle).
    - Boutons "Ajouter/Supprimer une opération".
- [ ] **Système de traçabilité** :
  - Filtres (par lot, par date, par état).
  - Tableau affichant l’historique (date, événement, pièce/lot concerné).
  - Graphique optionnel (ex : nombre de pièces produites par jour).

#### **🤖 Partie Automate (Codesys)**
- [ ] **Gestionnaire de programme journalier** :
  - Écran principal :
    - Liste des lots en attente (depuis la BDD).
    - Bouton "Lancer la production" (pour un lot sélectionné).
    - Affichage en temps réel :
      - État actuel (ex : "Production en cours : Lot AM203, pièce 5/1000").
      - Alertes (ex : "Barrière lumineuse coupée !").
  - Écran de suivi :
    - Historique des événements (comme dans l’exemple du mandat).
    - Bouton "Acquitter" pour les alarmes.

➡ **Outils recommandés** :
- [Figma](https://www.figma.com/) (gratuit, collaboratif).
- [Adobe XD](https://www.adobe.com/products/xd.html) (gratuit pour les étudiants).
- [Balsamiq](https://balsamiq.com/) (low-fidelity).

➡ **Délai** : **Mardi 28.04.2026 à 16h55** (remise du cahier des charges + maquettes).

---

## **📅 PHASE 3 : DÉVELOPPEMENT & DOCUMENTATION (Jusqu’au 16.06.2026)**
### **5️⃣ Développement (C# + Codesys)**
#### **🔹 Partie PC (C# – Windows Forms)**
- [ ] **Connexion à la BDD MySQL** :
  - Utiliser `MySql.Data.MySqlClient` ou `Entity Framework`.
  - Créer une classe `DatabaseManager` pour les requêtes.
- [ ] **Éditeur de lots** :
  - Implémenter les CRUD (Create, Read, Update, Delete) pour les lots.
  - Valider les données (ex : quantité > 0, nom unique).
- [ ] **Éditeur de recettes** :
  - CRUD pour les recettes et leurs opérations.
  - Gérer les contraintes (1 à 10 opérations max).
- [ ] **Système de traçabilité** :
  - Afficher l’historique depuis la table `HistoriqueProduction`.
  - Filtres dynamiques (par lot, date, état).
- [ ] **Tests unitaires** :
  - Vérifier les requêtes SQL, les validations, les affichages.

#### **🔹 Partie Automate (Codesys)**
- [ ] **Communication avec MySQL** :
  - Utiliser les bibliothèques Codesys pour MySQL (ex : `SQL4Automation`).
  - Lire les lots en attente depuis la BDD.
- [ ] **Gestion des lots** :
  - Lancer la production d’un lot sélectionné.
  - Envoyer des événements vers la BDD (début/fin de lot, pièces, alarmes).
- [ ] **Gestion des alarmes** :
  - Détecter les coupures de faisceau (simulé par le simulateur "Machine M2").
  - Envoyer une alerte dans l’historique.

### **6️⃣ Documentation technique**
- [ ] **Documentation C#** :
  - Commentaires dans le code (XML pour les méthodes).
  - Schéma de l’architecture (classes, interactions).
  - Guide d’installation (prérequis, configuration BDD).
- [ ] **Documentation Codesys** :
  - Explications des blocs fonctionnels.
  - Configuration de la communication MySQL.
- [ ] **Manuel utilisateur** :
  - Guide pas-à-pas pour :
    - Créer un lot/recette (PC).
    - Lancer une production (Automate).
    - Consulter l’historique.

### **7️⃣ Préparation de la présentation**
- [ ] **Support de présentation (PowerPoint/Google Slides)** :
  - Diapos clés :
    1. Contexte et objectifs.
    2. Architecture du système (schéma PC ↔ BDD ↔ Automate).
    3. Démonstration des maquettes (avant/après développement).
    4. Fonctionnalités implémentées (vidéos/captures).
    5. Difficultés rencontrées et solutions.
    6. Conclusion et améliorations possibles.
- [ ] **Démonstration live** :
  - Préparer un scénario (ex : création d’un lot → lancement production → alarme → traçabilité).
  - Tester sur le simulateur "Machine M2".
- [ ] **Répétition** :
  - Chronométrer la présentation (15-20 min max).
  - Prévoir des réponses aux questions possibles (ex : "Comment gérez-vous les erreurs de connexion BDD ?").

➡ **Délai** : **Mardi 16.06.2026 à 16h55** (remise des livrables).

---

## **📅 PHASE 4 : FINALISATION & REMISE (Jusqu’au 15.06.2026)**
### **8️⃣ Livrables finaux**
- [ ] **Fichiers sources** :
  - Dossier `Sources` avec :
    - Projet C# (solution Visual Studio).
    - Projet Codesys (export .project).
    - Scripts SQL (création BDD, données de test).
- [ ] **Documentation complète** :
  - Cahier des charges (version finale).
  - Rapport technique (architecture, choix techniques).
  - Manuel utilisateur.
  - Journal de travail (heures par catégorie, graphique).
- [ ] **Support de données** :
  - Clé USB ou lien cloud (Google Drive, GitHub) avec :
    - Tous les fichiers sources.
    - Documentation PDF.
    - Maquettes (Figma/Adobe XD).
    - Vidéo de démonstration (optionnel).

### **9️⃣ Préparation à la défense**
- [ ] **Revoir les critères d’évaluation** :
  - Traitement du sujet (pertinence des solutions).
  - Technique (qualité du code, BDD, communication).
  - Documentation (fond et forme).
  - Présentation (clarté, professionnalisme).
- [ ] **Anticiper les questions** :
  - "Pourquoi avoir choisi Windows Forms plutôt que WPF ?"
  - "Comment sécurisez-vous la communication entre le PC et l’automate ?"
  - "Quelles améliorations envisagez-vous ?"

---

## **📊 JOURNAL DE TRAVAIL (À METTRE À JOUR QUOTIDIENNEMENT)**
| Date       | Heure début | Heure fin | Catégorie          | Description de l’activité                          | Temps (h) |
|------------|-------------|-----------|--------------------|----------------------------------------------------|-----------|
| 20.03.2026 | 08:30       | 10:00     | Analyse            | Lecture du mandat et compréhension de la problématique | 1.5       |
| 21.03.2026 | 13:00       | 15:30     | Conception BDD     | Création du dictionnaire de données et MCD         | 2.5       |
| ...        | ...         | ...       | ...                | ...                                                | ...       |

➡ **Catégories possibles** :
- Analyse.
- Conception BDD.
- Maquettage.
- Développement C#.
- Développement Codesys.
- Documentation.
- Tests.
- Gestion de projet (réunions, planification).

---

## **🔹 CHECKLIST FINALE (À VÉRIFIER AVANT REMISE)**
- [ ] MCD et dictionnaire de données validés (30.03.2026).
- [ ] Cahier des charges complet avec maquettes (28.04.2026).
- [ ] Code C# fonctionnel (CRUD lots/recettes, traçabilité).
- [ ] Code Codesys opérationnel (communication MySQL, gestion des lots).
- [ ] Documentation technique et manuel utilisateur rédigés.
- [ ] Journal de travail à jour (heures totalisées, graphique).
- [ ] Support de présentation prêt (diapos + démonstration).
- [ ] Tous les fichiers sources et documents sur un support (clé USB/cloud).

---

### **💡 Conseils pour réussir**
1. **Prioriser les tâches** :
   - Commencez par le MCD (délai court) et le cahier des charges (base du projet).
2. **Collaborer efficacement** :
   - Utilisez Git (GitHub/GitLab) pour le code C#.
   - Partagez les maquettes sur Figma/Adobe XD pour feedbacks.
3. **Tester tôt** :
   - Testez la communication PC ↔ BDD dès que possible.
   - Utilisez le simulateur "Machine M2" pour valider Codesys.
4. **Documenter au fur et à mesure** :
   - Ne laissez pas la documentation pour la fin (risque d’oublis).
5. **Respecter les délais** :
   - Utilisez un diagramme de Gantt (ex : [GanttProject](https://www.ganttproject.biz/)) pour suivre l’avancement.

---

### **📅 PLANNING SIMPLIFIÉ**
| Période          | Objectifs principaux                          |
|------------------|-----------------------------------------------|
| **20.03 - 30.03** | Analyse + MCD                                 |
| **31.03 - 28.04** | Cahier des charges + Maquettage               |
| **29.04 - 16.06** | Développement (C# + Codesys) + Documentation  |
| **16.06 - 15.06** | Finalisation + Préparation présentation       |

---

Avec cette todo list, vous avez une **vision claire** des étapes à suivre et des livrables à produire. Bonne chance pour votre projet ! 🚀
/!\ GROUPE 4 /!\

**APERÇU DES ENDPOINTS**  

**1. Obtenir les Grilles (Grilles Complètes pour une Entreprise)**  
•	Endpoint : GET /api/grilles  
•	Description : Récupère une liste de grilles complètes pour une entreprise spécifiée, incluant le nom de l'entreprise, la question, la valeur de la réponse et les commentaires.  
•	Variables Requises :  
  •	idEntreprise : L'ID de l'entreprise pour laquelle les grilles sont demandées.  

**2. Obtenir les Axes Depuis les Grilles (Axes pour une Grille)**  
•	Endpoint : GET /api/grilles/{idAxe}/axes  
•	Description : Récupère les axes pour une grille spécifique basée sur l'ID de l'entreprise et de l'axe.  
•	Variables Requises :  
  •	idAxe : L'ID de l'axe.  
  •	idEntreprise : L'ID de l'entreprise.  

**3. Obtenir les Catégories Depuis l'ID de l'Axe (Catégories pour un Axe)**  
•	Endpoint : GET /api/axes/{id}/categories  
•	Description : Récupère une liste de catégories pour un ID d'axe donné.  
•	Variables Requises :  
  •	 id : L'ID de l'axe.  

**4. Obtenir les Questions Depuis une Catégorie (Questions pour une Catégorie)**  
•	Endpoint : GET /api/categories/{categorie}/questions  
•	Description : Récupère une liste de questions pour une catégorie spécifiée.  
•	Variables Requises :  
  •	categorie : Le nom de la catégorie.  

**5. Obtenir les Questions Depuis une Requête (Recherche de Questions)**  
•	Endpoint : GET /api/search/questions  
•	Description : Recherche des questions contenant une chaîne de requête spécifiée.  
•	Variables Requises :  
  •	q : La chaîne de requête à rechercher dans les questions.  

**6. Poster une Réponse (Ajouter une Réponse à une Question)**
•	Endpoint : POST /api/questions/{idQuestion}/reponses
•	Description : Ajoute une réponse à une question spécifique pour une entreprise.
•	Variables Requises :
  •	idQuestion : L'ID de la question.
  •	RootDataReponseQuestion : Un corps JSON contenant les détails de la réponse, incluant EntrepriseId, ReponseValue et Commentaire.

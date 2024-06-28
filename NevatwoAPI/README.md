**APER�U DES ENDPOINTS**

**1. Obtenir les Grilles (Grilles Compl�tes pour une Entreprise)**
�	Endpoint : GET /api/grilles
�	Description : R�cup�re une liste de grilles compl�tes pour une entreprise sp�cifi�e, incluant le nom de l'entreprise, la question, la valeur de la r�ponse et les commentaires.
�	Variables Requises :
�	idEntreprise : L'ID de l'entreprise pour laquelle les grilles sont demand�es.

**2. Obtenir les Axes Depuis les Grilles (Axes pour une Grille)**
�	Endpoint : GET /api/grilles/{idAxe}/axes
�	Description : R�cup�re les axes pour une grille sp�cifique bas�e sur l'ID de l'entreprise et de l'axe.
�	Variables Requises :
�	idAxe : L'ID de l'axe.
�	idEntreprise : L'ID de l'entreprise.

**3. Obtenir les Cat�gories Depuis l'ID de l'Axe (Cat�gories pour un Axe)**
�	Endpoint : GET /api/axes/{id}/categories
�	Description : R�cup�re une liste de cat�gories pour un ID d'axe donn�.
�	Variables Requises :
�	id : L'ID de l'axe.

**4. Obtenir les Questions Depuis une Cat�gorie (Questions pour une Cat�gorie)**
�	Endpoint : GET /api/categories/{categorie}/questions
�	Description : R�cup�re une liste de questions pour une cat�gorie sp�cifi�e.
�	Variables Requises :
�	categorie : Le nom de la cat�gorie.

**5. Obtenir les Questions Depuis une Requ�te (Recherche de Questions)**
�	Endpoint : GET /api/search/questions
�	Description : Recherche des questions contenant une cha�ne de requ�te sp�cifi�e.
�	Variables Requises :
�	q : La cha�ne de requ�te � rechercher dans les questions.

**6. Poster une R�ponse (Ajouter une R�ponse � une Question)**
�	Endpoint : POST /api/questions/{idQuestion}/reponses
�	Description : Ajoute une r�ponse � une question sp�cifique pour une entreprise.
�	Variables Requises :
�	idQuestion : L'ID de la question.
�	RootDataReponseQuestion : Un corps JSON contenant les d�tails de la r�ponse, incluant EntrepriseId, ReponseValue et Commentaire.
# 🤝 Beitrag zu BulletGraph

Willkommen! 🎯  
Danke, dass du zur Weiterentwicklung von BulletGraph beitragen möchtest – einem kompakten 2D-Tool zur Visualisierung ballistischer Flugbahnen.

Dieses Dokument erklärt, wie du effektiv zum Projekt beitragen kannst.

---

## 📋 Inhalt

1. Voraussetzungen  
2. Projektstruktur  
3. Entwicklungsablauf  
4. Codestil  
5. Feature-Vorschläge  
6. Bug Reports  
7. Sicherheit  
8. Lizenz  
9. Kontakt

---

## 1. Voraussetzungen

Bevor du loslegst, stelle bitte sicher:

- Du arbeitest mit Visual Studio 2022 oder VS Code
- Du hast .NET 8.0 (oder neuer) installiert
- Du kennst dich mit C# und WinForms (oder wenigstens GUI-Grundlagen) aus

---

## 2. Projektstruktur

Bitte halte dich an diese logische Modulstruktur:

- **/Core** → Physik, Ballistik, Zeitsimulation  
- **/Rendering** → Grafische Darstellung, Skalierung, Zeichenlogik  
- **/UI** → Forms, Panels, Benutzeroberfläche  
- **/Logging** → (optional) spätere Fehler- und Zustandsprotokollierung

Beispiel:

- Flugbahnformel? → `Core/TrajectoryCalculator.cs`
- Zeichnen der Kurve? → `Rendering/GraphRenderer.cs`
- Eingabefelder und Buttons? → `UI/Form1.cs`

---

## 3. Entwicklungsablauf

### Schrittweise Mitarbeit:

1. Forke das Repository
2. Erstelle einen neuen Branch für deine Änderung:
   ```bash
   git checkout -b feature/dein-feature-name
   ```
3. Nimm deine Änderungen vor
4. Teste lokal, ob alles läuft
5. Committe mit aussagekräftiger Nachricht:
   ```bash
   git commit -m "Füge dynamische Skalierung für Flugbahn hinzu"
   ```
6. Erstelle einen Pull Request auf den `main`-Branch

---

## 4. Codestil

Bitte halte dich an diese Richtlinien:

- `PascalCase` für:
  - Klassen (`TrajectoryCalculator`)
  - Methoden (`CalculateTrajectory`)
- `camelCase` für:
  - Felder (`startHeight`)
  - lokale Variablen (`scaleX`, `maxY`)
- Verwende sinnvolle Kommentare nur dort, wo der Code nicht selbsterklärend ist
- Formatiere logisch in Blöcken: Eingabe → Berechnung → Zeichnung
- Halte `Form1.cs` schlank: Vermeide komplexe Logik direkt im Form

---

## 5. Feature-Vorschläge

Gute Ideen sind willkommen. Damit sie leicht umsetzbar sind, sollte ein Feature:

- Einen klaren Nutzen bringen (z. B. mehrere Flugbahnen vergleichen)
- Visuell sinnvoll integrierbar sein
- Möglichst keine externen Abhängigkeiten einführen
- Nicht gegen das Ziel des Projekts verstoßen: **minimal, offline, 2D**

---

## 6. Bug Reports

Wenn du einen Fehler findest, beschreibe ihn bitte möglichst genau:

- Welche Eingabewerte wurden genutzt?
- Was war das erwartete Verhalten?
- Was ist stattdessen passiert?
- Passiert es immer oder nur manchmal?
- Falls möglich: Screenshot oder kurze Beschreibung

Beispiele für Bugs:

- App stürzt bei bestimmten Eingaben ab
- Graph wird nicht angezeigt
- Skalierung stimmt nicht bei sehr hohen Werten

---

## 7. Sicherheit

Auch ein lokales Simulationsprogramm kann sicherheitsbewusst entwickelt werden.

Bitte beachte:

- Eingaben prüfen (`float.TryParse`, gültige Wertebereiche)
- Negative Werte für Höhe, Winkel oder Geschwindigkeit abfangen
- Simulation in `try-catch`-Blöcke setzen
- Bei Multithreading (z. B. GameLoop) Synchronisation beachten

---

## 8. Lizenz

Mit deinem Beitrag erklärst du dich einverstanden, dass dein Code unter der bestehenden Lizenz (MIT) veröffentlicht wird.

Du bleibst natürlich namentlich Urheber deiner Änderungen (via Git-Historie).

---

## 9. Kontakt

Fragen? Verbesserungsvorschläge? Melde dich direkt beim Projektbetreuer.

Danke für deinen Beitrag – wir schätzen jede Idee, jede Zeile Code und jedes Feedback. 🚀

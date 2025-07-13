# 🔐 Security Policy for BulletGraph

This project simulates ballistic trajectories in a controlled desktop environment.  
Even though it's a local visualization tool, we take user and system safety seriously.

---

## 🛡️ Supported Versions

| Version | Status       |
|---------|--------------|
| 1.x     | ✅ Supported |
| < 1.0   | ❌ Unsupported |

---

## 🧩 Scope of Security

This software is a **2D ballistic graph simulator**. The following aspects are **in scope** for security:

- ✅ Input validation for user-provided values (angle, speed, height)
- ✅ Application stability (e.g., no crashing on invalid input)
- ✅ Code safety (no unsafe memory operations or threading issues)

The following are **out of scope**:

- ❌ Network security (project has no network layer)
- ❌ Data storage security (no persistent data written)
- ❌ Access control (single-user desktop app)

---

## 📥 Reporting a Vulnerability

If you find a vulnerability, bug, or unexpected behavior related to input safety or execution stability:

- 📧 Please contact: `tobe-sec@yourdomain.example`
- Or open an issue with `[SECURITY]` in the title.

We aim to respond within **7 days** to valid reports.

---

## 🔒 Best Practices

If you modify or extend this project, consider the following:

- Sanitize user inputs (no negative speeds, absurd angles, etc.)
- Protect multi-threaded logic with synchronization if shared data is introduced
- Avoid dynamic code execution or unsafe libraries

---

## 🧪 Development Tips

Use `try-catch` for physics simulation steps and log all invalid input conditions.  
Visual feedback should never trigger crashes.

---

## 🏁 Final Note

This is a non-networked, standalone desktop simulation tool. While low-risk, safe coding is still a priority.

Stay safe and shoot simulations responsibly. 🎯

// ROUTES:
// Defines client-side route configurations using React Router, mapping URLs to page components

import { Route, Routes } from "react-router-dom";
import App from "../App";
import { LoginPage } from "../pages/LoginPage";
import { ProtectedRoute } from "../hooks/ProtectedRoute";
import { CreateOperationalRestriction } from "../pages/CreateOperationalRestriction";

export function AppRoutes() {
  return (
    <Routes>
      <Route path="/" element={<LoginPage />} />
      <Route path="/login" element={<LoginPage />} />

      <Route element={<ProtectedRoute />}>
        <Route path="/home" element={<App />} />

        <Route
          path="/create-operational-restriction"
          element={<CreateOperationalRestriction />}
        />
      </Route>
    </Routes>
  );
}

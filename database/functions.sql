CREATE OR REPLACE FUNCTION trigger_set_updated_at()
RETURNS TRIGGER AS $$
BEGIN
    new.updatedAt = now();
    return new;
END;
$$ LANGUAGE plpgsql;

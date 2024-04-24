BEGIN TRAN
CREATE ROLE NV
GRANT UPDATE (SoLuong) ON dbo.HANG_HOA TO NV;
GRANT SELECT, REFERENCES ON dbo.NXB TO NV;
GRANT SELECT, REFERENCES ON dbo.VAN_PHONG_PHAM TO NV;
GRANT SELECT, INSERT, REFERENCES ON dbo.KHACH_HANG TO NV;
GRANT SELECT, UPDATE (SoDiem) ON dbo.THE_TV TO NV;
GRANT SELECT, REFERENCES ON dbo.NHAN_VIEN TO NV;
GRANT SELECT, REFERENCES ON dbo.TAI_KHOAN_DN TO NV;
GRANT SELECT, INSERT, REFERENCES ON dbo.LS_DANG_NHAP TO NV;
GRANT SELECT, INSERT, REFERENCES ON dbo.TAO_TV TO NV;
GRANT SELECT, INSERT, REFERENCES ON dbo.HOA_DON_BAN TO NV;
GRANT SELECT, INSERT, REFERENCES ON dbo.BAN_HANG TO NV;
COMMIT TRAN


-- BEGIN TRAN 
-- 	  CREATE LOGIN [nvv1353] WITH PASSWORD = 'MK123456', DEFAULT_DATABASE = Proj_DBMS_BookStore, CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
-- 	  GO
-- 	  CREATE USER nvv1353 FOR LOGIN nvv1353
-- 	  GO
-- 	  ALTER ROLE NV ADD MEMBER nvv1353
-- 	  GO
-- COMMIT TRAN
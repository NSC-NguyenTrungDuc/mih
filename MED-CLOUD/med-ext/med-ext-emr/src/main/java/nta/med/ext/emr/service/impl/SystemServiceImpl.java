package nta.med.ext.emr.service.impl;

import nta.med.ext.emr.service.SystemService;
import org.springframework.stereotype.Service;

/**
 * @author DEV-TiepNM
 */
@Service
public class SystemServiceImpl implements SystemService{

    public boolean authenticate(String login, String password, String hospCode)
    {
        return false; //systemAdapter.authenticate(login, password, hospCode);
    }
}

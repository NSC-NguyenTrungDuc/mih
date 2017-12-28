package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.service.ihis.proto.SystemServiceProto;

/**
 * @author DEV-TiepNM
 */
@Service
@Scope("prototype")
public class FormSelectHospCodeHandler extends ScreenHandler<SystemServiceProto.FormSelectHospCodeRequest, SystemServiceProto.FormSelectHospCodeResponse> {

    @Resource
    Bas0001Repository bas0001Repository;
    @Override
    public boolean isAuthorized(Vertx vertx, String sessionId){
       return true;
    }
    @Override
    @Transactional(readOnly = true)
    @Route(global = true)
    public SystemServiceProto.FormSelectHospCodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, SystemServiceProto.FormSelectHospCodeRequest request) throws Exception {
        SystemServiceProto.FormSelectHospCodeResponse.Builder response = SystemServiceProto.FormSelectHospCodeResponse.newBuilder();
        List<Bas0001> bas0001s = bas0001Repository.findLatestByHospCode(request.getHospCode());
        if (CollectionUtils.isEmpty(bas0001s)) {
            return response.build();
        } else {
            String hospCode = bas0001s.get(0).getHospCode();
            String hospName = StringUtils.isEmpty(bas0001s.get(0).getYoyangName()) ? bas0001s.get(0).getYoyangName2() : bas0001s.get(0).getYoyangName();
            String vpnYn = StringUtils.isEmpty(bas0001s.get(0).getVpnYn()) ? "" : bas0001s.get(0).getVpnYn();
            String certExpired = "";
            String language = bas0001s.get(0).getLanguage();
            if(bas0001s.get(0).getCertExpired() != null){
            	certExpired = DateUtil.toString(bas0001s.get(0).getCertExpired(), DateUtil.PATTERN_YYMMDD);
            }
            return response.setHospCode(hospCode)
            		.setHospName(hospName)
            		.setVpnYn(vpnYn)
            		.setCertExpired(certExpired)
            		.setLanguage(language)
            		.build();
        }
    }
}

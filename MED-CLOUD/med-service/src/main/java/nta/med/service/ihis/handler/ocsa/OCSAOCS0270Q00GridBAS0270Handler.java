package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.ocsa.OCSAOCS0270Q00GridBAS0270RowInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCSAOCS0270Q00GridBAS0270Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCSAOCS0270Q00GridBAS0270Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OCSAOCS0270Q00GridBAS0270Handler
	extends ScreenHandler<OcsaServiceProto.OCSAOCS0270Q00GridBAS0270Request,OcsaServiceProto.OCSAOCS0270Q00GridBAS0270Response> {
	
    @Resource
    private Bas0270Repository bas0270Repository;
    
    @Override
    @Transactional(readOnly = true)
    public OCSAOCS0270Q00GridBAS0270Response handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCSAOCS0270Q00GridBAS0270Request request) throws Exception {
    	String hospCode = request.getHospCode();
    	if(StringUtils.isEmpty(hospCode)){
    		hospCode = getHospitalCode(vertx, sessionId);
    	}
    	
     	List<OCSAOCS0270Q00GridBAS0270RowInfo> listItem = bas0270Repository.getOCSAOCS0270Q00GridBAS0270RowInfo(getLanguage(vertx, sessionId), hospCode,
        		request.getAllGubun(), request.getGwa(), request.getDoctorGrade(), request.getQuery(), request.getOsimGubun(), request.getDate(), request.getReserOutYn());
     	
        OcsaServiceProto.OCSAOCS0270Q00GridBAS0270Response.Builder response = OcsaServiceProto.OCSAOCS0270Q00GridBAS0270Response.newBuilder();
        
        if (listItem != null && !listItem.isEmpty()) {
            for (OCSAOCS0270Q00GridBAS0270RowInfo item : listItem) {
            	OcsaModelProto.OCSAOCS0270Q00GridBAS0270RowInfo.Builder info = OcsaModelProto.OCSAOCS0270Q00GridBAS0270RowInfo.newBuilder();
            	if(!StringUtils.isEmpty(item.getDoctor())){
            		info.setDoctor(item.getDoctor());
            	}
            	if(!StringUtils.isEmpty(item.getDoctorName())){
            		info.setDoctorName(item.getDoctorName());
            	}
            	if(!StringUtils.isEmpty(item.getContKey())){
            		info.setContKey(item.getContKey());
            	}
            	if(!StringUtils.isEmpty(item.getDepartmentName())){
            		info.setDepartmentName(item.getDepartmentName());
            	}
                response.addRows(info);
            }
        }
        return response.build();
    }
}

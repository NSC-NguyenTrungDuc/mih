package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl3023Repository;
import nta.med.data.model.ihis.cpls.CPL0000Q00ResultListQuerySelect1ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q00ResultListQuerySelect1Request;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q00ResultListQuerySelect1Response;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;
@Service
@Scope("prototype")
public class CPL0000Q00ResultListQuerySelect1Handler extends ScreenHandler<CplsServiceProto.CPL0000Q00ResultListQuerySelect1Request, CplsServiceProto.CPL0000Q00ResultListQuerySelect1Response> {
	private static final Log LOG = LogFactory.getLog(CPL0000Q00ResultListQuerySelect1Handler.class);
	@Resource
	private Cpl3023Repository cpl3023Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL0000Q00ResultListQuerySelect1Response handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL0000Q00ResultListQuerySelect1Request request) throws Exception {
        CplsServiceProto.CPL0000Q00ResultListQuerySelect1Response.Builder response = CplsServiceProto.CPL0000Q00ResultListQuerySelect1Response.newBuilder();
        List<CPL0000Q00ResultListQuerySelect1ListItemInfo> listItem = cpl3023Repository.getCPL0000Q00ResultListQuerySelect1Request(getHospitalCode(vertx, sessionId), request.getSpecimenSer(), 
        		request.getSrlCode(), request.getJundalGubun());
        if(!CollectionUtils.isEmpty(listItem)) {
        	for(CPL0000Q00ResultListQuerySelect1ListItemInfo item : listItem) {
        		CplsModelProto.CPL0000Q00ResultListQuerySelect1ListItemInfo.Builder info = CplsModelProto.CPL0000Q00ResultListQuerySelect1ListItemInfo.newBuilder();
        		if (item.getSerial() != null) {
        			info.setSerial(item.getSerial().toString());
        		}
        		if (!StringUtils.isEmpty(item.getKyunResult())) {
        			info.setKyunResult(item.getKyunResult());
        		}
        		if (!StringUtils.isEmpty(item.getKyunCode())) {
        			info.setKyunCode(item.getKyunCode());
        		}
        		if (!StringUtils.isEmpty(item.getMicName())) {
        			info.setMicName(item.getMicName());
        		}
        		if (!StringUtils.isEmpty(item.getMicResult())) {
        			info.setMicResult(item.getMicResult());
        		}

        		response.addResultList(info);
        	}
        }
		            
		return response.build();
	}

}

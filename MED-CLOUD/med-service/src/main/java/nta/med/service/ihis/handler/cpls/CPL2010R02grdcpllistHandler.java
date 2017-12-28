package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.model.ihis.cpls.CPL2010R02grdcpllistInfo;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010R02grdcpllistRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010R02grdcpllistResponse;

@Service                                                                                                          
@Scope("prototype") 
public class CPL2010R02grdcpllistHandler extends ScreenHandler<CplsServiceProto.CPL2010R02grdcpllistRequest, CplsServiceProto.CPL2010R02grdcpllistResponse>{
	@Resource
	private Ocs1003Repository ocs1003Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public CPL2010R02grdcpllistResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CPL2010R02grdcpllistRequest request) throws Exception {
		CplsServiceProto.CPL2010R02grdcpllistResponse.Builder response = CplsServiceProto.CPL2010R02grdcpllistResponse.newBuilder();
		List<CPL2010R02grdcpllistInfo> list = ocs1003Repository.getCPL2010R02grdcpllistInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId)
													, request.getInOutGubun()
													, request.getBunho()
													, request.getOrderDate()
													, request.getGwa()
													, request.getDoctor()
													, request.getSpecimenCode()
													, request.getReOutput()
													, request.getFkinp1001());
		if (!CollectionUtils.isEmpty(list)) {
			for (CPL2010R02grdcpllistInfo item : list) {
				CplsModelProto.CPL2010R02grdcpllistInfo.Builder info = CplsModelProto.CPL2010R02grdcpllistInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdMasterItem(info);
			}
		}
		return response.build();
	}

}

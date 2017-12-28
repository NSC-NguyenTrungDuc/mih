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
import nta.med.data.model.ihis.cpls.CPL2010R02grdOrderListInfo;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010R02grdOrderListRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010R02grdOrderListResponse;

@Service                                                                                                          
@Scope("prototype") 
public class CPL2010R02grdOrderListHandler extends ScreenHandler<CplsServiceProto.CPL2010R02grdOrderListRequest, CplsServiceProto.CPL2010R02grdOrderListResponse>{
	@Resource
	private Ocs1003Repository ocs1003Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public CPL2010R02grdOrderListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CPL2010R02grdOrderListRequest request) throws Exception {
		CplsServiceProto.CPL2010R02grdOrderListResponse.Builder response = CplsServiceProto.CPL2010R02grdOrderListResponse.newBuilder();
		List<CPL2010R02grdOrderListInfo> list = ocs1003Repository.getCPL2010R02grdOrderListInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId)
														, request.getBunho()
														, request.getOrderDate()
														, request.getReOutput());
		if (!CollectionUtils.isEmpty(list)) {
			for (CPL2010R02grdOrderListInfo item : list) {
				CplsModelProto.CPL2010R02grdOrderListInfo.Builder info = CplsModelProto.CPL2010R02grdOrderListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdMasterItem(info);
			}
		}
		return response.build();
	}

}

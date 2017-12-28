package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.nuro.NuroSearchPatientInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010R02fbxBunhoDataValidatingRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010R02fbxBunhoDataValidatingResponse;

@Service                                                                                                          
@Scope("prototype") 
public class CPL2010R02fbxBunhoDataValidatingHandler extends ScreenHandler<CplsServiceProto.CPL2010R02fbxBunhoDataValidatingRequest, CplsServiceProto.CPL2010R02fbxBunhoDataValidatingResponse>{
	@Resource
	private Out0101Repository out0101Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public CPL2010R02fbxBunhoDataValidatingResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, CPL2010R02fbxBunhoDataValidatingRequest request) throws Exception {
		CplsServiceProto.CPL2010R02fbxBunhoDataValidatingResponse.Builder response = CplsServiceProto.CPL2010R02fbxBunhoDataValidatingResponse.newBuilder();
		List<NuroSearchPatientInfo> list = out0101Repository.getNuroSearchPatientInfo(getHospitalCode(vertx, sessionId), request.getBunho());
		if (!CollectionUtils.isEmpty(list)) {
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
			info.setDataValue(list.get(0).getPatientName1());
			response.setFbxbunhoItem(info);
		}
		return response.build();
	}

}

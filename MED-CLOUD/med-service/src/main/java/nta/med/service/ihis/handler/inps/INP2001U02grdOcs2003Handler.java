package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.model.ihis.inps.INP2001U02grdOcs2003Info;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP2001U02grdOcs2003Request;
import nta.med.service.ihis.proto.InpsServiceProto.INP2001U02grdOcs2003Response;

@Service
@Scope("prototype")
public class INP2001U02grdOcs2003Handler extends
		ScreenHandler<InpsServiceProto.INP2001U02grdOcs2003Request, InpsServiceProto.INP2001U02grdOcs2003Response> {

	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP2001U02grdOcs2003Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP2001U02grdOcs2003Request request) throws Exception {
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		Double fkinp1001 = CommonUtils.parseDouble(request.getFkInp1001());
		
		InpsServiceProto.INP2001U02grdOcs2003Response.Builder response = InpsServiceProto.INP2001U02grdOcs2003Response.newBuilder(); 
		List<INP2001U02grdOcs2003Info> listInfo = ocs2003Repository.getListINP2001U02grdOcs2003Info(hospCode, language, request.getBunho(), fkinp1001);
		
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		for (INP2001U02grdOcs2003Info info : listInfo) {
			InpsModelProto.INP2001U02grdOcs2003Info.Builder infoBuilder = InpsModelProto.INP2001U02grdOcs2003Info.newBuilder();
			BeanUtils.copyProperties(info, infoBuilder, language);
			response.addGrd2003(infoBuilder);
		}
		
		return response.build();
	}

}

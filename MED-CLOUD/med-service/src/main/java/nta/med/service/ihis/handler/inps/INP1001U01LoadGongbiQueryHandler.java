package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.inp.Inp1008;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.inp.Inp1008Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01LoadGongbiQueryRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class INP1001U01LoadGongbiQueryHandler
		extends ScreenHandler<InpsServiceProto.INP1001U01LoadGongbiQueryRequest, SystemServiceProto.ComboResponse> {

	@Resource
	private Inp1008Repository inp1008Repository;
	
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01LoadGongbiQueryRequest request) throws Exception {
		
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		List<CommonModelProto.DataStringListItemInfo> lstParam = request.getGongbiCodeListList();
		if(CollectionUtils.isEmpty(lstParam)){
			return response.build();
		}
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String fkout1001 = request.getFkinp1002();
		
		for (CommonModelProto.DataStringListItemInfo param : lstParam) {
			CommonModelProto.ComboListItemInfo.Builder protoInfo = CommonModelProto.ComboListItemInfo.newBuilder();
			
			List<Inp1008> lstResult = inp1008Repository.findByHospCodeGongbiCodeFkInp1002(hospCode, param.getDataValue(), fkout1001);
			if(CollectionUtils.isEmpty(lstResult)){
				protoInfo.setCode("").setCodeName("");
			} else {
				Inp1008 inp1008 = lstResult.get(0);
				protoInfo.setCode(inp1008.getGongbiCode() == null ? "" : inp1008.getGongbiCode())
						 .setCodeName(inp1008.getPriority() == null ? "" : String.valueOf(inp1008.getPriority()));
			}
			
			response.addComboItem(protoInfo);
		}
		
		return response.build();
	}

}

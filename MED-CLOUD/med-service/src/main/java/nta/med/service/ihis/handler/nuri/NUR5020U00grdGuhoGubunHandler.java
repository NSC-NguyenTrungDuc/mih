package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.nur.Nur5021Repository;
import nta.med.data.model.ihis.nuri.NUR5020U00grdGuhoGubunInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00grdGuhoGubunRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00grdGuhoGubunResponse;

@Service
@Scope("prototype")
public class NUR5020U00grdGuhoGubunHandler extends
		ScreenHandler<NuriServiceProto.NUR5020U00grdGuhoGubunRequest, NuriServiceProto.NUR5020U00grdGuhoGubunResponse> {
	
	@Resource
	private Nur5021Repository nur5021Repository;
	
	@Resource
	private Inp1001Repository inp1001Repository;

	@Override
	public NUR5020U00grdGuhoGubunResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR5020U00grdGuhoGubunRequest request) throws Exception {

		NUR5020U00grdGuhoGubunResponse.Builder response = NUR5020U00grdGuhoGubunResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List <NUR5020U00grdGuhoGubunInfo> result;
		
		if(request.getQueryNumber().equals("1")){
			result = inp1001Repository.getNUR5020U00grdGuhoGubunInfoMode1(hospCode, request.getHoDong(), request.getDate(), startNum, offset);
		}else {
			result = nur5021Repository.getNUR5020U00grdGuhoGubunInfoMode2(hospCode, request.getHoDong(), request.getDate(), startNum, offset);
		}
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR5020U00grdGuhoGubunInfo item : result){
				NuriModelProto.NUR5020U00grdGuhoGubunInfo.Builder info = NuriModelProto.NUR5020U00grdGuhoGubunInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addGrdMasterItem(info);
			}
		}
		
		return response.build();
	}

	
}

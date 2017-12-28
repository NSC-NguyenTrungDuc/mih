package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur1020Repository;
import nta.med.data.model.ihis.nuri.NUR1020U00grdNUR1020Info;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00grdNUR1020Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00grdNUR1020Response;

@Service
@Scope("prototype")
public class NUR1020U00grdNUR1020Handler extends
		ScreenHandler<NuriServiceProto.NUR1020U00grdNUR1020Request, NuriServiceProto.NUR1020U00grdNUR1020Response> {

	@Resource
	private Nur1020Repository nur1020Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR1020U00grdNUR1020Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020U00grdNUR1020Request request) throws Exception {
		NuriServiceProto.NUR1020U00grdNUR1020Response.Builder response = NuriServiceProto.NUR1020U00grdNUR1020Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR1020U00grdNUR1020Info> listData = nur1020Repository.getNUR1020U00grdNUR1020Info(hospCode
				, request.getBunho()
				, CommonUtils.parseDouble(request.getFkinp1001())
				, request.getDate());
		
		for (NUR1020U00grdNUR1020Info item : listData) {
			NuriModelProto.NUR1020U00grdNUR1020Info.Builder info = NuriModelProto.NUR1020U00grdNUR1020Info.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			
			if(item.getFkinp1001() != null){
				info.setFkinp1001(String.format("%.0f",item.getFkinp1001()));
			}
			
			if(item.getPrGubun1() != null){
				info.setPrGubun1(String.format("%.0f",item.getPrGubun1()));
			}
			
			if(item.getPrGubun2() != null){
				info.setPrGubun2(String.format("%.0f",item.getPrGubun2()));
			}
			
			if(item.getPrGubun3() != null){
				info.setPrGubun3(String.format("%.0f",item.getPrGubun3()));
			}
			
			if(item.getPrGubun4() != null){
				info.setPrGubun4(String.format("%.0f",item.getPrGubun4()));
			}
			
			if(item.getPrGubun5() != null){
				info.setPrGubun5(String.format("%.0f",item.getPrGubun5()));
			}
			
			if(item.getPrGubun6() != null){
				info.setPrGubun6(String.format("%.0f",item.getPrGubun6()));
			}
			
			if(item.getPrGubun7() != null){
				info.setPrGubun7(String.format("%.0f",item.getPrGubun7()));
			}
			
			if(item.getPrGubun8() != null){
				info.setPrGubun8(String.format("%.0f",item.getPrGubun8()));
			}
			
			response.addGrdMasterItem(info);
		}
		
		return response.build();
	}

}

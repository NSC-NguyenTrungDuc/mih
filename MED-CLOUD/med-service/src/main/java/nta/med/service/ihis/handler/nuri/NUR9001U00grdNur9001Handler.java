package nta.med.service.ihis.handler.nuri;

import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur9001Repository;
import nta.med.data.model.ihis.nuri.NUR9001U00grdNur9001Info;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR9001U00grdNur9001Handler extends ScreenHandler<NuriServiceProto.NUR9001U00grdNur9001Request, NuriServiceProto.NUR9001U00grdNur9001Response> {
	
	@Resource
	private Nur9001Repository nur9001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR9001U00grdNur9001Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR9001U00grdNur9001Request request) throws Exception {
				
		NuriServiceProto.NUR9001U00grdNur9001Response.Builder response = NuriServiceProto.NUR9001U00grdNur9001Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<NUR9001U00grdNur9001Info> result = nur9001Repository.getNUR9001U00grdNur9001Info(hospCode, request.getFromDate(), request.getToDate(),
				request.getBunho(), CommonUtils.parseDouble(request.getFkinp1001()), startNum, offset);
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR9001U00grdNur9001Info item : result){
				NuriModelProto.NUR9001U00grdNur9001Info.Builder info = NuriModelProto.NUR9001U00grdNur9001Info.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				if (item.getFkinp1001() != null) {
					info.setFkinp1001(String.format("%.0f",item.getFkinp1001()));
				}
				if (item.getFknur4001() != null) {
					info.setFknur4001(String.format("%.0f",item.getFknur4001()));
				}
				if (item.getPknur9001() != null) {
					info.setPknur9001(String.format("%.0f",item.getPknur9001()));
				}
				response.addGrdNur9001(info);
			}
		}
		
		return response.build();
	}
}

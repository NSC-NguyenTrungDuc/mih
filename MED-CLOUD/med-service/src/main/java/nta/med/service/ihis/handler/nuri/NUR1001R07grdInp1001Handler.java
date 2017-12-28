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
import nta.med.data.model.ihis.nuri.NUR1001R07grdInp1001Info;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1001R07grdInp1001Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1001R07grdInp1001Response;

@Service
@Scope("prototype")
public class NUR1001R07grdInp1001Handler extends
		ScreenHandler<NuriServiceProto.NUR1001R07grdInp1001Request, NuriServiceProto.NUR1001R07grdInp1001Response> {

	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	public NUR1001R07grdInp1001Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1001R07grdInp1001Request request) throws Exception {
		
		NuriServiceProto.NUR1001R07grdInp1001Response.Builder response = NuriServiceProto.NUR1001R07grdInp1001Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<NUR1001R07grdInp1001Info> result = inp1001Repository.getNUR1001R07grdInp1001Info(hospCode, language, request.getBunho(), startNum, offset);
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR1001R07grdInp1001Info item : result){
				NuriModelProto.NUR1001R07grdInp1001Info.Builder info = NuriModelProto.NUR1001R07grdInp1001Info.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				if (item.getPkinp1001() != null) {
					info.setPkinp1001(String.format("%.0f",item.getPkinp1001()));
				}
				response.addItems(info);
			}
		}
		
		return response.build();
	}

	
}

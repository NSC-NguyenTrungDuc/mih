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
import nta.med.data.dao.medi.inp.Inp2004Repository;
import nta.med.data.model.ihis.nuri.NUR1001R07grdInp2004Info;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1001R07grdInp2004Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1001R07grdInp2004Response;

@Service
@Scope("prototype")
public class NUR1001R07grdInp2004Handler extends
		ScreenHandler<NuriServiceProto.NUR1001R07grdInp2004Request, NuriServiceProto.NUR1001R07grdInp2004Response> {
	
	@Resource
	private Inp2004Repository inp2004Repository;

	@Override
	public NUR1001R07grdInp2004Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1001R07grdInp2004Request request) throws Exception {
		
		NuriServiceProto.NUR1001R07grdInp2004Response.Builder response = NuriServiceProto.NUR1001R07grdInp2004Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<NUR1001R07grdInp2004Info> result = inp2004Repository.getNUR1001R07grdInp2004Info(hospCode, language, CommonUtils.parseDouble(request.getFkinp1001()),
				request.getBunho(), startNum, offset);
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR1001R07grdInp2004Info item : result){
				NuriModelProto.NUR1001R07grdInp2004Info.Builder info = NuriModelProto.NUR1001R07grdInp2004Info.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				if (item.getFkinp1001() != null) {
					info.setFkinp1001(String.format("%.0f",item.getFkinp1001()));
				}
				response.addItems(info);
			}
		}
		
		return response.build();
	}

}

package nta.med.service.ihis.handler.nuri;

import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.nuri.NUR9001U00grdPalistInfo;

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
public class NUR9001U00grdPalistHandler extends ScreenHandler<NuriServiceProto.NUR9001U00grdPalistRequest, NuriServiceProto.NUR9001U00grdPalistResponse> {
	
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR9001U00grdPalistResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR9001U00grdPalistRequest request) throws Exception {
				
		NuriServiceProto.NUR9001U00grdPalistResponse.Builder response = NuriServiceProto.NUR9001U00grdPalistResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<NUR9001U00grdPalistInfo> result = inp1001Repository.getNUR9001U00grdPalistInfo(hospCode, request.getHoDong(), request.getDate(),
				request.getA(), request.getB(), request.getC(), request.getD(), startNum, offset);
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR9001U00grdPalistInfo item : result){
				NuriModelProto.NUR9001U00grdPalistInfo.Builder info = NuriModelProto.NUR9001U00grdPalistInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				if (item.getPkinp1001() != null) {
					info.setPkinp1001(String.format("%.0f",item.getPkinp1001()));
				}
				response.addListPalist(info);
			}
		}
		
		return response.build();
	}
}

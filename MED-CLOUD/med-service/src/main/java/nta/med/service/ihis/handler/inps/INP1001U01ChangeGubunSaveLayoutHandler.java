package nta.med.service.ihis.handler.inps;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.inp.Inp1002;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0210Repository;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.inp.Inp1002Repository;
import nta.med.data.model.ihis.inps.PrInpMakePkinp1002;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01ChangeGubunSaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service                                                                                                          
@Scope("prototype") 
@Transactional
public class INP1001U01ChangeGubunSaveLayoutHandler extends ScreenHandler<InpsServiceProto.INP1001U01ChangeGubunSaveLayoutRequest, SystemServiceProto.UpdateResponse>{
	@Resource
	private Bas0210Repository bas0210Repository;
	@Resource
	private Inp1001Repository inp1001Repository;
	@Resource
	private Inp1002Repository inp1002Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01ChangeGubunSaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		if (StringUtils.isEmpty(request.getGubunStart2())) {
			response.setMsg("358");
			response.setResult(false);
			return response.build();
		}
		String userId = getUserId(vertx, sessionId);
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String dupCheck = bas0210Repository.getBAS0210U00DupCheckext(language, request.getGubun(), DateUtil.toDate(request.getGubunIpwonDate(), DateUtil.PATTERN_YYMMDD));
		if (StringUtils.isEmpty(dupCheck) || (!StringUtils.isEmpty(dupCheck) && !"Y".equals(dupCheck))){
			response.setMsg("338");
			response.setResult(false);
			return response.build();
		}	
		
		String gongbiYn = bas0210Repository.getNuroChkGetGongbiYN(request.getGubun(), request.getGubunIpwonDate(), language);
		if (StringUtils.isEmpty(gongbiYn)){
			response.setMsg("361");
			response.setResult(false);
			return response.build();
		}
		
		List<String> listJohap = bas0210Repository.getBAS0111U00LayGetJohap(request.getGubun(), request.getGubunIpwonDate(), language);
		String johapGubun;
		if (CollectionUtils.isEmpty(listJohap)) {
			response.setMsg("334");
			response.setResult(false);
			return response.build();
		} else 
			johapGubun = listJohap.get(0);
		
		PrInpMakePkinp1002 result = inp1001Repository.callPrInpMakePkinp1002(request.getFkinp1001Proc(), request.getGubunProc(), hospCode);
		if (result != null) {
			if (StringUtils.isEmpty(result.getPkinp1002())) {
				response.setMsg("189");
				response.setResult(false);
				return response.build();
			}
		}
		
		Double maxGubunTransCnt = inp1002Repository.getMaxGubunTransCnt(hospCode, request.getFkinp1001());
		Double maxGubunTransCntSubtractOne = maxGubunTransCnt - 1;
		String cnt = "0";
		if (maxGubunTransCnt != null)
			cnt = CommonUtils.parseString(maxGubunTransCnt);
		if (!"1".equals(cnt)) {
			Integer result1 = inp1002Repository.iNP1001U01ChangeGubunUpdateInp1002(userId, request.getGubunIpwonDate(), hospCode, CommonUtils.parseDouble(request.getFkinp1001()), maxGubunTransCntSubtractOne);
			if (result1 < 0) {
				response.setMsg("保険変更に失敗しました。");
				response.setResult(false);
				return response.build();
			}
		}
		
		Inp1002 inp1002 = new Inp1002();
		inp1002.setSysDate(new Date());
		inp1002.setSysId(userId);
		inp1002.setUpdDate(new Date());
		inp1002.setUpdId(userId);
		inp1002.setHospCode(hospCode);
		inp1002.setPkinp1002(result.getPkinp1002());
		inp1002.setFkinp1001(CommonUtils.parseDouble(request.getFkinp1001()));
		inp1002.setBunho(request.getMBunho());
		inp1002.setGubun(request.getGubun());
		inp1002.setSeq(CommonUtils.parseDouble(CommonUtils.parseString(result.getSeq())));
		inp1002.setGubunTransDate(null);
		inp1002.setGubunIpwonDate(DateUtil.toDate(request.getGubunIpwonDate(), DateUtil.PATTERN_YYMMDD));
		inp1002.setGubunToiwonDate(null);
		inp1002.setGubunTransCnt(maxGubunTransCnt);
		inp1002.setGubunTransYn("N");
		inp1002.setSimsaja(null);
		inp1002.setSimsaMagamYn(null);
		Inp1002 inp1002Check = inp1002Repository.save(inp1002);
		if (inp1002Check == null) {
			response.setMsg("保険変更に失敗しました。");
			response.setResult(false);
			return response.build();
		}
		
		response.setResult(true);
		return response.build();
	}

}

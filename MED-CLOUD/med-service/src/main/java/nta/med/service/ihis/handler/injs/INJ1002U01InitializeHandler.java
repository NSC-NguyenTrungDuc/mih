package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inj.Inj1002Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.injs.INJ1002U01GrdOrderListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InjsModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class INJ1002U01InitializeHandler extends ScreenHandler<InjsServiceProto.INJ1002U01InitializeRequest, InjsServiceProto.INJ1002U01InitializeResponse> {
	private static final Log LOG = LogFactory.getLog(INJ1002U01InitializeHandler.class);
	@Resource
	private Inj1002Repository inj1002Repository;
	
	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Override
	public boolean isValid(InjsServiceProto.INJ1002U01InitializeRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getReserDate()) && DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ1002U01InitializeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ1002U01InitializeRequest request) throws Exception {
		InjsServiceProto.INJ1002U01InitializeResponse.Builder response = InjsServiceProto.INJ1002U01InitializeResponse.newBuilder();
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
        List<INJ1002U01GrdOrderListItemInfo> listResult = inj1002Repository.getINJ1002U01Initialize(hospitalCode, language, request.getBunho1(),  request.getReserDate());
        if (!CollectionUtils.isEmpty(listResult)) {
        	InjsModelProto.INJ1002U01GrdOrderListItemInfo.Builder info = InjsModelProto.INJ1002U01GrdOrderListItemInfo.newBuilder();
        	for (INJ1002U01GrdOrderListItemInfo item : listResult) {
        		if (item.getGroupSer() != null) {
        			info.setGroupSer(item.getGroupSer().toString());
        		}
        		if (item.getPkinj1002() != null) {
        			info.setPkinj1002(item.getPkinj1002().toString());
        		}
        		if (item.getFkinj1001() != null) {
        			info.setFkinj1001(item.getFkinj1001().toString());
        		}
        		if (item.getFkocs1003() != null) {
        			info.setFkocs1003(item.getFkocs1003().toString());
        		}
        		if (!StringUtils.isEmpty(item.getHangmogName())) {
        			info.setHangmogName(item.getHangmogName());
        		}
        		if (item.getSeq() != null) {
        			info.setSeq(item.getSeq().toString());
        		}
        		if (!StringUtils.isEmpty(item.getTonggyeCode())) {
        			info.setTonggyeCode(item.getTonggyeCode());
        		}
        		if (item.getMagamDate() != null) {
        			info.setMagamDate(DateUtil.toString(item.getMagamDate(), DateUtil.PATTERN_YYMMDD));
        		}
        		if (!StringUtils.isEmpty(item.getMagamJangso())) {
        			info.setMagamJangso(item.getMagamJangso());
        		}
        		if (item.getMagamSer() != null) {
        			info.setMagamSer(item.getMagamSer().toString());
        		}
        		if (!StringUtils.isEmpty(item.getReserDate())) {
        			info.setReserDate(item.getReserDate());
        		}
        		if (!StringUtils.isEmpty(item.getReserTime())) {
        			info.setReserTime(item.getReserTime());
        		}
        		if (!StringUtils.isEmpty(item.getJubsuDate())) {
        			info.setJubsuDate(item.getJubsuDate());
        		}
        		if (!StringUtils.isEmpty(item.getHangmogCode())) {
        			info.setHangmogCode(item.getHangmogCode());
        		}
        		if (!StringUtils.isEmpty(item.getJusaBuui())) {
        			info.setJusaBuui(item.getJusaBuui());
        		}
        		if (!StringUtils.isEmpty(item.getActingJangso())) {
        			info.setActingJangso(item.getActingJangso());
        		}
        		if (!StringUtils.isEmpty(item.getActingDate())) {
        			info.setActingDate(item.getActingDate());
        		}
        		if (!StringUtils.isEmpty(item.getActingTime())) {
        			info.setActingTime(item.getActingTime());
        		}
        		if (!StringUtils.isEmpty(item.getCompanyCode())) {
        			info.setCompanyCode(item.getCompanyCode());
        		}
        		if (!StringUtils.isEmpty(item.getLotNo())) {
        			info.setLotNo(item.getLotNo());
        		}
        		if (!StringUtils.isEmpty(item.getChasuCode())) {
        			info.setChasuCode(item.getChasuCode());
        		}
        		if (!StringUtils.isEmpty(item.getPwResult())) {
        			info.setPwResult(item.getPwResult());
        		}
        		if (!StringUtils.isEmpty(item.getCsResult())) {
        			info.setCsResult(item.getCsResult());
        		}
        		if (!StringUtils.isEmpty(item.getAst())) {
        			info.setAst(item.getAst());
        		}
        		if (!StringUtils.isEmpty(item.getActingFlag())) {
        			info.setActingFlag(item.getActingFlag());
        		}
        		if (item.getSunabSuryang() != null) {
        			info.setSunabSuryang(item.getSunabSuryang().toString());
        		}
        		if (!StringUtils.isEmpty(item.getSunabDate())) {
        			info.setSunabDate(item.getSunabDate());
        		}
        		if (item.getFkout1001() != null) {
        			info.setFkout1001(item.getFkout1001().toString());
        		}
        		if (!StringUtils.isEmpty(item.getCancerYn())) {
        			info.setCancerYn(item.getCancerYn());
        		}
        		if (!StringUtils.isEmpty(item.getBunho())) {
        			info.setBunho(item.getBunho());
        		}
        		if (!StringUtils.isEmpty(item.getRemarkChk())) {
        			info.setRemarkChk(item.getRemarkChk());
        		}
        		if (!StringUtils.isEmpty(item.getDcYn())) {
        			info.setDcYn(item.getDcYn());
        		}
        		if (!StringUtils.isEmpty(item.getJusaTongCnt())) {
        			info.setJusaTongCnt(item.getJusaTongCnt());
        		}
        		if (!StringUtils.isEmpty(item.getOtherBuseoYn())) {
        			info.setOtherBuseoYn(item.getOtherBuseoYn());
        		}
        		if (!StringUtils.isEmpty(item.getJujongja())) {
        			info.setJujongja(item.getJujongja());
        		}
        		if (!StringUtils.isEmpty(item.getJujongjaName())) {
        			info.setJujongjaName(item.getJujongjaName());
        		}
        		if (!StringUtils.isEmpty(item.getYebangJujongChk())) {
        			info.setYebangJujongChk(item.getYebangJujongChk());
        		}
        		if (!StringUtils.isEmpty(item.getActdayChk())) {
        			info.setActdayChk(item.getActdayChk());
        		}
        		if (!StringUtils.isEmpty(item.getFnBasLoadGwaName())) {
        			info.setFnBasLoadGwaName(item.getFnBasLoadGwaName());
        		}
        		if (!StringUtils.isEmpty(item.getBannabYn())) {
        			info.setBannabYn(item.getBannabYn());
        		}
        		if (!StringUtils.isEmpty(item.getSkinYn())) {
        			info.setSkinYn(item.getSkinYn());
        		}
        		if (!StringUtils.isEmpty(item.getChungguDate())) {
        			info.setChungguDate(item.getChungguDate());
        		}
        		if (!StringUtils.isEmpty(item.getOrderDate())) {
        			info.setOrderDate(item.getOrderDate());
        		}
        		if (!StringUtils.isEmpty(item.getDoctor())) {
        			info.setDoctor(item.getDoctor());
        		}
        		if (!StringUtils.isEmpty(item.getOrdDanui())) {
        			info.setOrdDanui(item.getOrdDanui());
        		}
        		if (!StringUtils.isEmpty(item.getHopeDateYn())) {
        			info.setHopeDateYn(item.getHopeDateYn());
        		}
        		if (!StringUtils.isEmpty(item.getBogyongCode())) {
        			info.setBogyongCode(item.getBogyongCode());
        		}
        		if (item.getSuryang() != null) {
        			info.setSuryang(item.getSuryang().toString());
        		}
        		if (item.getDv() != null) {
        			info.setDv(item.getDv().toString());
        		}
        		if (!StringUtils.isEmpty(item.getDvTime())) {
        			info.setDvTime(item.getDvTime());
        		}
        		if (!StringUtils.isEmpty(item.getSlipCode())) {
        			info.setSlipCode(item.getSlipCode());
        		}
        		if (item.getfOrderDate() != null) {
        			info.setFOrderDate(DateUtil.toString(item.getfOrderDate(), DateUtil.PATTERN_YYMMDD));
        		}
        		if (!StringUtils.isEmpty(item.getMixGroup())) {
        			info.setMixGroup(item.getMixGroup());
        		}
        		if (item.getHopeDate() != null) {
        			info.setHopeDate(DateUtil.toString(item.getHopeDate(), DateUtil.PATTERN_YYMMDD));
        		}
        		if (!StringUtils.isEmpty(item.getOrderGubun())) {
        			info.setOrderGubun(item.getOrderGubun());
        		}
	            response.addGrdOrderList(info);
        	}
        }
        
        List<ComboListItemInfo> listComboItem = ocs0132Repository.getInjsComboListItemInfo(hospitalCode, language, "JUSA");
        if (!CollectionUtils.isEmpty(listComboItem)) {
        	CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
        	for (ComboListItemInfo item : listComboItem) {
        		if (!StringUtils.isEmpty(item.getCode())) {
        			info.setCode(item.getCode());
        		}
        		if (!StringUtils.isEmpty(item.getCodeName())) {
        			info.setCodeName(item.getCodeName());
        		}
        		response.addXEditGridCell19List(info);
        	}
        }
        
        List<String> listReserDate = inj1002Repository.getINJ1002U01InitializeReserDate(hospitalCode, request.getBunho2());
        if (!CollectionUtils.isEmpty(listReserDate)) {
        	for (String item : listReserDate) {
        		if (!StringUtils.isEmpty(item)) {
        			response.addReserDate(item);
        		}
        	}
        }
		return response.build();
	}
}

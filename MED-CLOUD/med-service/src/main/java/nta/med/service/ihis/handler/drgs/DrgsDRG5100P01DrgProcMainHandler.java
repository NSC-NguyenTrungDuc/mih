package nta.med.service.ihis.handler.drgs;

import nta.med.core.caching.model.medi.drgs.InformationSchemaColumn;
import nta.med.core.config.Configuration;
import nta.med.core.domain.drg.Drg4010;
import nta.med.core.domain.ifs.*;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.com.ComSeqRepository;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.dao.medi.drg.Drg4010Repository;
import nta.med.data.dao.medi.ifs.*;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01CurDrgOrderInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01DrgMasterInsertResponseInfo;
import nta.med.service.CommonHandler;
import nta.med.service.caching.CacheService;
import nta.med.service.ihis.proto.DrgsServiceProto;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.math.BigInteger;
import java.util.Date;
import java.util.List;
import java.util.Map;

@Transactional
@Service
@Scope("prototype")
public class DrgsDRG5100P01DrgProcMainHandler extends CommonHandler<DrgsServiceProto.DrgsDRG5100P01DrgProcMainRequest, DrgsServiceProto.DrgsDRG5100P01DrgProcMainResponse> {
    private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01DrgProcMainHandler.class);
    
    @Autowired
    private Configuration configuration;
    
    @Resource
    public CacheService cacheService;

    public Map<String, InformationSchemaColumn> mapIfs7101 = null;

    public Map<String, InformationSchemaColumn> mapIfs7102 = null;

    public Map<String, InformationSchemaColumn> mapIfs7103 = null;

    public Map<String, InformationSchemaColumn> mapIfs7104 = null;

    public Map<String, InformationSchemaColumn> mapIfs7106 = null;

    public Map<String, InformationSchemaColumn> mapIfs7107 = null;


    @Resource
    private Drg2010Repository drg2010Repository;

    @Resource
    private Drg3010Repository drg3010Repository;

    @Resource
    private ComSeqRepository comSeqRepository;

    @Resource
    private Drg4010Repository drg4010Repository;

    @Resource
    private Ifs7101Repository ifs7101Repository;

    @Resource
    private Ifs7102Repository ifs7102Repository;

    @Resource
    private Ifs7103Repository ifs7103Repository;

    @Resource
    private Ifs7104Repository ifs7104Repository;

    @Resource
    private Ifs7105Repository ifs7105Repository;

    @Resource
    private Ifs7106Repository ifs7106Repository;

    @Resource
    private Ifs7107Repository ifs7107Repository;

    @Override
    public DrgsServiceProto.DrgsDRG5100P01DrgProcMainResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01DrgProcMainRequest request) throws Exception {
        DrgsServiceProto.DrgsDRG5100P01DrgProcMainResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01DrgProcMainResponse.newBuilder();
        Double masterPk = CommonUtils.parseDouble(request.getMasterFk());
        String hospitalCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        DrgsDRG5100P01DrgMasterInsertResponseInfo result = drgProcMain(hospitalCode, request.getIoGubun(),
                masterPk, request.getSendYn(), hospitalCode, language);

        if (result.getoFlag().equals("1")) {
            response.setResult(true);
        } else {
            response.setResult(false);
        }
        return response.build();
    }

    public String drgGetPatternDv(Integer patternSeq, DrgsDRG5100P01CurDrgOrderInfo drg5100p01CurDrgOrderInfo) {
        if (patternSeq == 1) {
            return String.format("%.0f", drg5100p01CurDrgOrderInfo.getDv1());
        } else if (patternSeq == 2) {
            return String.format("%.0f", drg5100p01CurDrgOrderInfo.getDv2());
        } else if (patternSeq == 3) {
            return String.format("%.0f", drg5100p01CurDrgOrderInfo.getDv3());
        } else if (patternSeq == 4) {
            return String.format("%.0f", drg5100p01CurDrgOrderInfo.getDv4());
        } else if (patternSeq == 5) {
            return String.format("%.0f", drg5100p01CurDrgOrderInfo.getDv5());
        } else if (patternSeq == 6) {
            return String.format("%.0f", drg5100p01CurDrgOrderInfo.getDv6());
        } else if (patternSeq == 7) {
            return String.format("%.0f", drg5100p01CurDrgOrderInfo.getDv7());
        } else if (patternSeq == 8) {
            return String.format("%.0f", drg5100p01CurDrgOrderInfo.getDv8());
        } else {
            return "-1";
        }
    }

    public Ifs7106 loadUnbalanceDv(Integer patternSeq, Integer patternPos, DrgsDRG5100P01CurDrgOrderInfo drg5100p01CurDrgOrderInfo, Ifs7106 inIfs7106) {
        Ifs7106 outIfs7106 = inIfs7106;
        if (patternPos == 1) {
            outIfs7106.setUnbalance1(drgGetPatternDv(patternSeq, drg5100p01CurDrgOrderInfo));
        } else if (patternPos == 2) {
            outIfs7106.setUnbalance2(drgGetPatternDv(patternSeq, drg5100p01CurDrgOrderInfo));
        } else if (patternPos == 3) {
            outIfs7106.setUnbalance3(drgGetPatternDv(patternSeq, drg5100p01CurDrgOrderInfo));
        } else if (patternPos == 4) {
            outIfs7106.setUnbalance4(drgGetPatternDv(patternSeq, drg5100p01CurDrgOrderInfo));
        } else if (patternPos == 5) {
            outIfs7106.setUnbalance5(drgGetPatternDv(patternSeq, drg5100p01CurDrgOrderInfo));
        } else {
            String unbalanceX = drgGetPatternDv(patternSeq, drg5100p01CurDrgOrderInfo);
            outIfs7106.setUnbalanceX(unbalanceX + unbalanceX + unbalanceX);
        }

        return outIfs7106;
    }

    public String ifsPad7101(String column, String dataType, String value) {
        return fnIfsPad(column, dataType, value, mapIfs7101, configuration.getSchema()+":IFS7101");
    }

    public String ifsPad7102(String column, String dataType, String value) {
        return fnIfsPad(column, dataType, value, mapIfs7102, configuration.getSchema()+":IFS7102");
    }

    public String ifsPad7103(String column, String dataType, String value) {
        return fnIfsPad(column, dataType, value, mapIfs7103, configuration.getSchema()+":IFS7103");
    }

    public String ifsPad7104(String column, String dataType, String value) {
        return fnIfsPad(column, dataType, value, mapIfs7104, configuration.getSchema()+":IFS7104");
    }

    public String ifsPad7106(String column, String dataType, String value) {
        return fnIfsPad(column, dataType, value, mapIfs7106, configuration.getSchema()+":IFS7106");
    }

    public String ifsPad7107(String column, String dataType, String value) {
        return fnIfsPad(column, dataType, value, mapIfs7107, configuration.getSchema()+":IFS7107");
    }


    /**
     * Migrate procedure DRG4010_IUD to java
     *
     * @param iudGubun
     * @param inDrg4010
     * @return
     */
    public Double drg4010IUD(String iudGubun, Drg4010 inDrg4010) {
        try {
            Double pk = inDrg4010.getPkdrg4010();
            Double seq;
            String seqKey;
            if (iudGubun.equals("D")) {
                if (!drg4010Repository.deleteDrg4010(inDrg4010.getHospCode(), inDrg4010.getPkdrg4010())) {
                    return -1D;
                }
            } else if (iudGubun.equals("U-")) {
                if (!drg4010Repository.deleteDrg4010(inDrg4010.getHospCode(), inDrg4010.getPkdrg4010())) {
                    return -1D;
                }
                return insertDrg4010(inDrg4010);
            } else if (iudGubun.equals("IR")) {
                return insertDrg4010(inDrg4010);
            } else if (iudGubun.equals("I")) {
                pk = drg4010Repository.getDrg4010Seq("DRG4010_SEQ").doubleValue();
                seqKey = inDrg4010.getHospCode() + DateUtil.toString(inDrg4010.getJubsuDate(), DateUtil.PATTERN_YYMMDD_BLANK) + StringUtils.leftPad(String.format("%.0f", inDrg4010.getDrgBunho()), 10, "0");
                seq = drg4010Repository.getMaxSeq(inDrg4010.getHospCode(), seqKey);

                inDrg4010.setPkdrg4010(pk);
                inDrg4010.setSeq(seq);

                return insertDrg4010(inDrg4010);
            } else if (iudGubun.equals("UF")) {
                if (!drg4010Repository.updateDrg4010(inDrg4010.getUpdDate(), inDrg4010.getUpdId(), inDrg4010.getIfSendFlag(), inDrg4010.getHospCode(), inDrg4010.getPkdrg4010())) {
                    return -1D;
                }
            }
            return pk;
        } catch (Exception e) {
            LOG.error(e.getMessage(), e);
            return -1D;
        }
    }

    public Double insertDrg4010(Drg4010 inDrg4010) {
        try {
            Drg4010 drg4010 = new Drg4010();
            drg4010.setSysId(inDrg4010.getSysId());
            drg4010.setSysDate(inDrg4010.getSysDate());
            drg4010.setUpdId(inDrg4010.getUpdId());
            drg4010.setUpdDate(inDrg4010.getUpdDate());
            drg4010.setHospCode(inDrg4010.getHospCode());
            drg4010.setPkdrg4010(inDrg4010.getPkdrg4010());
            drg4010.setJubsuDate(inDrg4010.getJubsuDate());
            drg4010.setDrgBunho(inDrg4010.getDrgBunho());
            drg4010.setSeq(inDrg4010.getSeq());
            drg4010.setDataDubun(inDrg4010.getDataDubun());
            drg4010.setInOutGubun(inDrg4010.getInOutGubun());
            drg4010.setBunho(inDrg4010.getBunho());
            drg4010.setFkout1001(inDrg4010.getFkout1001());
            drg4010.setFkinp1001(inDrg4010.getFkinp1001());
            drg4010.setIfSendFlag(inDrg4010.getIfSendFlag());

            drg4010Repository.save(drg4010);
            return inDrg4010.getPkdrg4010();
        } catch (Exception e) {
            LOG.error(e.getMessage(), e);
            return -1D;
        }
    }

    /**
     * Migrate PROCEDURE IFS7101_IUD to java
     *
     * @param iudGubun
     * @param inIfs7101
     * @return
     */
    public Double ifs7101IUD(String iudGubun, Ifs7101 inIfs7101) {
        try {
            Double pk = inIfs7101.getPkifs7101();
            if (iudGubun.equals("D")) {
                if (!ifs7101Repository.deleteIfs7101(inIfs7101.getHospCode(), inIfs7101.getPkifs7101())) {
                    return -1D;
                }
            } else if (iudGubun.equals("IR")) {
                return insertIfs7101(inIfs7101);
            } else if (iudGubun.equals("U-")) {
                if (!ifs7101Repository.deleteIfs7101(inIfs7101.getHospCode(), inIfs7101.getPkifs7101())) {
                    return -1D;
                }
                return insertIfs7101(inIfs7101);
            } else if (iudGubun.equals("UF")) {
                return ifs7101Repository.updateIfs7101(inIfs7101.getUpdId(), inIfs7101.getUpdDate(), inIfs7101.getIfDate(),
                        inIfs7101.getIfTime(), inIfs7101.getIfFlag(), inIfs7101.getIfErr(), inIfs7101.getHospCode(), inIfs7101.getPkifs7101()).doubleValue();
            } else if (iudGubun.equals("I")) {
                inIfs7101.setPkifs7101(ifs7101Repository.getIfs7101Seq("IFS7101_SEQ").doubleValue());
                inIfs7101.setOrdNo(ifsPad7101("ORD_NO", "VARCHAR", String.format("%.0f", inIfs7101.getPkifs7101())));

                return insertIfs7101(inIfs7101);
            }

            return pk;
        } catch (Exception e) {
            LOG.error(e.getMessage(), e);
            return -1D;
        }
    }

    public Double insertIfs7101(Ifs7101 inIfs7101) {
        try {
            Ifs7101 ifs7101 = new Ifs7101();
            ifs7101.setSysId(inIfs7101.getSysId());
            ifs7101.setSysDate(inIfs7101.getSysDate());
            ifs7101.setUpdId(inIfs7101.getUpdId());
            ifs7101.setUpdDate(inIfs7101.getUpdDate());
            ifs7101.setHospCode(inIfs7101.getHospCode());
            ifs7101.setPkifs7101(inIfs7101.getPkifs7101());
            ifs7101.setRecGubun(inIfs7101.getRecGubun());
            ifs7101.setEndFlag(inIfs7101.getEndFlag());
            ifs7101.setIoGubun(inIfs7101.getIoGubun());
            ifs7101.setDrgOrdGubun(inIfs7101.getDrgOrdGubun());
            ifs7101.setIpToiwonGubun(inIfs7101.getIpToiwonGubun());
            ifs7101.setDataGubun(inIfs7101.getDataGubun());
            ifs7101.setOrdNo(inIfs7101.getOrdNo());
            ifs7101.setJubsuBunho(inIfs7101.getJubsuBunho());
            ifs7101.setSendDate(inIfs7101.getSendDate());
            ifs7101.setSendTime(inIfs7101.getSendTime());
            ifs7101.setJojeDate(inIfs7101.getJojeDate());
            ifs7101.setBogyongStartDate(inIfs7101.getBogyongStartDate());
            ifs7101.setHoDong(inIfs7101.getHoDong());
            ifs7101.setHoDongName(inIfs7101.getHoDongName());
            ifs7101.setGwa(inIfs7101.getGwa());
            ifs7101.setGwaName(inIfs7101.getGwaName());
            ifs7101.setHoCode(inIfs7101.getHoCode());
            ifs7101.setHoCodeName(inIfs7101.getHoCodeName());
            ifs7101.setDoctor(inIfs7101.getDoctor());
            ifs7101.setDoctorName(inIfs7101.getDoctorName());
            ifs7101.setRpCnt(inIfs7101.getRpCnt());
            ifs7101.setOrdCmtCnt(inIfs7101.getOrdCmtCnt());
            ifs7101.setDrgInfoPrtYn(inIfs7101.getDrgInfoPrtYn());
            ifs7101.setDrgMybookPrtYn(inIfs7101.getDrgMybookPrtYn());
            ifs7101.setPrinterGubun(inIfs7101.getPrinterGubun());
            ifs7101.setPrintGubun(inIfs7101.getPrintGubun());
            ifs7101.setBaebunFlag(inIfs7101.getBaebunFlag());
            ifs7101.setOrdResultCode(inIfs7101.getOrdResultCode());
            ifs7101.setOrdActYn(inIfs7101.getOrdActYn());
            ifs7101.setOrdNoSrc(inIfs7101.getOrdNoSrc());
            ifs7101.setRemark(inIfs7101.getRemark());
            ifs7101.setFkdrg4010(inIfs7101.getFkdrg4010());
            ifs7101.setIfDate(inIfs7101.getIfDate());
            ifs7101.setIfTime(inIfs7101.getIfTime());
            ifs7101.setIfFlag(inIfs7101.getIfFlag());
            ifs7101.setIfErr(inIfs7101.getIfErr());

            ifs7101Repository.save(ifs7101);

            return ifs7101.getPkifs7101();
        } catch (Exception e) {
            LOG.error(e.getMessage(), e);
            return -1D;
        }
    }

    /**
     * Migrate PROCEDURE IFS7102_IUD to java
     *
     * @param iudGubun
     * @param inIfs7102
     * @return
     */
    public Double ifs7102UID(String iudGubun, Ifs7102 inIfs7102) {
        try {
            Double pk = inIfs7102.getSeq();
            if (iudGubun.equals("D")) {
                if (!ifs7102Repository.deleteIfs7102(inIfs7102.getHospCode(), inIfs7102.getFkifs7101(), inIfs7102.getSeq())) {
                    return -1D;
                }
            } else if (iudGubun.equals("IR")) {
                return insertIfs7102(inIfs7102);
            } else if (iudGubun.equals("U-")) {
                if (!ifs7102Repository.deleteIfs7102(inIfs7102.getHospCode(), inIfs7102.getFkifs7101(), inIfs7102.getSeq())) {
                    return -1D;
                }
                return insertIfs7102(inIfs7102);
            } else if (iudGubun.equals("I")) {
                String seqKey = inIfs7102.getHospCode() + StringUtils.leftPad(String.format("%.0f", inIfs7102.getFkifs7101()), 10, "0");
                Double seq = ifs7102Repository.getMaxSeq(inIfs7102.getHospCode(), seqKey);
                inIfs7102.setSeq(seq);
                return insertIfs7102(inIfs7102);
            }

            return pk;
        } catch (Exception e) {
            LOG.error(e.getMessage(), e);
            return -1D;
        }
    }

    public Double insertIfs7102(Ifs7102 inIfs7102) {
        try {
            Ifs7102 ifs7102 = new Ifs7102();
            ifs7102.setSysId(inIfs7102.getSysId());
            ifs7102.setSysDate(inIfs7102.getSysDate());
            ifs7102.setUpdId(inIfs7102.getUpdId());
            ifs7102.setUpdDate(inIfs7102.getUpdDate());
            ifs7102.setHospCode(inIfs7102.getHospCode());
            ifs7102.setFkifs7101(inIfs7102.getFkifs7101());
            ifs7102.setSeq(inIfs7102.getSeq());
            ifs7102.setRecGubun(inIfs7102.getRecGubun());

            ifs7102.setEndFlag(inIfs7102.getEndFlag());
            ifs7102.setOrdCmtCode(inIfs7102.getOrdCmtCode());
            ifs7102.setOrdCmtCodeName(inIfs7102.getOrdCmtCodeName());
            ifs7102.setRemark(inIfs7102.getRemark());

            ifs7102Repository.save(ifs7102);
            return ifs7102.getSeq();
        } catch (Exception e) {
            LOG.error(e.getMessage(), e);
            return -1D;
        }
    }

    /**
     * Migrate PROCEDURE IFS7103_IUD to java
     *
     * @param iudGubun
     * @param inIfs7103
     * @return
     */
    public Double ifs7103IUD(String iudGubun, Ifs7103 inIfs7103) {
        try {
            Double pk = inIfs7103.getFkifs7101();
            if (iudGubun.equals("D")) {
                if (!ifs7103Repository.deleteIfs7103(inIfs7103.getHospCode(), inIfs7103.getFkifs7101())) {
                    return -1D;
                }
            } else if (iudGubun.equals("IR") || iudGubun.equals("I")) {
                return insertIfs7103(inIfs7103);
            } else if (iudGubun.equals("U-")) {
                if (!ifs7103Repository.deleteIfs7103(inIfs7103.getHospCode(), inIfs7103.getFkifs7101())) {
                    return -1D;
                }
                return insertIfs7103(inIfs7103);
            }

            return pk;
        } catch (Exception e) {
            LOG.error(e.getMessage(), e);
            return -1D;
        }
    }

    public Double insertIfs7103(Ifs7103 inIfs7103) {
        try {
            Ifs7103 ifs7103 = new Ifs7103();
            ifs7103.setSysId(inIfs7103.getSysId());
            ifs7103.setSysDate(inIfs7103.getSysDate());
            ifs7103.setUpdId(inIfs7103.getUpdId());
            ifs7103.setUpdDate(inIfs7103.getUpdDate());
            ifs7103.setHospCode(inIfs7103.getHospCode());
            ifs7103.setFkifs7101(inIfs7103.getFkifs7101());
            ifs7103.setRecGubun(inIfs7103.getRecGubun());
            ifs7103.setEndFlag(inIfs7103.getEndFlag());
            ifs7103.setBunho(inIfs7103.getBunho());
            ifs7103.setName(inIfs7103.getName());
            ifs7103.setNameKana(inIfs7103.getNameKana());
            ifs7103.setSex(inIfs7103.getSex());
            ifs7103.setBirthday(inIfs7103.getBirthday());
            ifs7103.setDrgPackYn(inIfs7103.getDrgPackYn());
            ifs7103.setPowderYn(inIfs7103.getPowderYn());
            ifs7103.setRemark(inIfs7103.getRemark());

            ifs7103Repository.save(inIfs7103);
            return inIfs7103.getFkifs7101();
        } catch (Exception e) {
            LOG.error(e.getMessage(), e);
            return -1D;
        }
    }

    /**
     * Migrate PROCEDURE IFS7104_IUD to java
     *
     * @param iudGubun
     * @param inIfs7104
     * @return
     */
    public Double ifs7104IUD(String iudGubun, Ifs7104 inIfs7104) {
        try {
            Double pk = inIfs7104.getSeqRp();
            if (iudGubun.equals("D")) {
                if (!ifs7104Repository.deleteIfs7104(inIfs7104.getHospCode(), inIfs7104.getFkifs7101(), inIfs7104.getSeqRp())) {
                    return -1D;
                }
            } else if (iudGubun.equals("IR")) {
                return insertIfs7104(inIfs7104);
            } else if (iudGubun.equals("U-")) {
                if (!ifs7104Repository.deleteIfs7104(inIfs7104.getHospCode(), inIfs7104.getFkifs7101(), inIfs7104.getSeqRp())) {
                    return -1D;
                }
                return insertIfs7104(inIfs7104);
            } else if (iudGubun.equals("I")) {
                String seqkey = inIfs7104.getHospCode() + StringUtils.leftPad(String.format("%.0f", inIfs7104.getFkifs7101()), 10, "0");
                Double seq = ifs7104Repository.getMaxSeq(inIfs7104.getHospCode(), seqkey);
                inIfs7104.setSeqRp(seq);
                return insertIfs7104(inIfs7104);
            }
            return pk;
        } catch (Exception e) {
            LOG.error(e.getMessage(), e);
            return -1D;
        }
    }

    public Double insertIfs7104(Ifs7104 inIfs7104) {
        try {
            ifs7104Repository.save(inIfs7104);
            return inIfs7104.getSeqRp();
        } catch (Exception e) {
            LOG.error(e.getMessage(), e);
            return -1D;
        }
    }

    /**
     * Migrate PROCEDURE IFS7105_IUD to java
     *
     * @param iudGubun
     * @param inIfs7105
     * @return
     */
    public Double ifs7105IUD(String iudGubun, Ifs7105 inIfs7105) {
        try {
            Double pk = inIfs7105.getSeq();
            if (iudGubun.equals("D")) {
                if (!ifs7105Repository.deleteIfs7105(inIfs7105.getHospCode(), inIfs7105.getFkifs7101(), inIfs7105.getSeqRp(), inIfs7105.getSeq())) {
                    return -1D;
                }
            } else if (iudGubun.equals("IR")) {
                return insertIfs7105(inIfs7105);
            } else if (iudGubun.equals("U-")) {
                if (!ifs7105Repository.deleteIfs7105(inIfs7105.getHospCode(), inIfs7105.getFkifs7101(), inIfs7105.getSeqRp(), inIfs7105.getSeq())) {
                    return -1D;
                }
                return insertIfs7105(inIfs7105);
            } else if (iudGubun.equals("I")) {
                String seqkey = inIfs7105.getHospCode() + StringUtils.leftPad(String.format("%.0f", inIfs7105.getFkifs7101()), 10, "0")
                        + StringUtils.leftPad(String.format("%.0f", inIfs7105.getSeqRp()), 10, "0");
                Double seq = ifs7105Repository.getMaxSeq(inIfs7105.getHospCode(), seqkey);
                inIfs7105.setSeq(seq);
                return insertIfs7105(inIfs7105);
            }
            return pk;
        } catch (Exception e) {
            LOG.error(e.getMessage(), e);
            return -1D;
        }
    }

    public Double insertIfs7105(Ifs7105 inIfs7105) {
        try {
            ifs7105Repository.save(inIfs7105);
            return inIfs7105.getSeq();
        } catch (Exception e) {
            LOG.error(e.getMessage(), e);
            return -1D;
        }
    }

    /**
     * Migrate PROCEDURE IFS7106_IUD to java
     *
     * @param iudGubun
     * @param inIfs7106
     * @return
     */
    public Double ifs7106IUD(String iudGubun, Ifs7106 inIfs7106) {
        try {
            Double pk = inIfs7106.getSeqRpDrg();
            if (iudGubun.equals("D")) {
                if (!ifs7106Repository.deleteIfs7106(inIfs7106.getHospCode(), inIfs7106.getFkifs7101(), inIfs7106.getSeqRp(), inIfs7106.getSeqRpDrg())) {
                    return -1D;
                }
            } else if (iudGubun.equals("IR")) {
                return insertIfs7106(inIfs7106);
            } else if (iudGubun.equals("U-")) {
                if (!ifs7106Repository.deleteIfs7106(inIfs7106.getHospCode(), inIfs7106.getFkifs7101(), inIfs7106.getSeqRp(), inIfs7106.getSeqRpDrg())) {
                    return -1D;
                }
                return insertIfs7106(inIfs7106);
            } else if (iudGubun.equals("I")) {
                String seqkey = inIfs7106.getHospCode() + StringUtils.leftPad(String.format("%.0f", inIfs7106.getFkifs7101()), 10, "0")
                        + StringUtils.leftPad(String.format("%.0f", inIfs7106.getSeqRp()), 10, "0");
                Double seq = ifs7106Repository.getMaxSeq(inIfs7106.getHospCode(), seqkey);
                inIfs7106.setSeqRpDrg(seq);
                return insertIfs7106(inIfs7106);
            }
            return pk;
        } catch (Exception e) {
            LOG.error(e.getMessage(), e);
            return -1D;
        }
    }

    public Double insertIfs7106(Ifs7106 inIfs7106) {
        try {
            ifs7106Repository.save(inIfs7106);
            return inIfs7106.getSeqRpDrg();
        } catch (Exception e) {
            LOG.error(e.getMessage(), e);
            return -1D;
        }
    }

    /**
     * Migrate PROCEDURE IFS7107_IUD to java
     *
     * @param iudGubun
     * @param inifs7107
     * @return
     */
    public Double ifs7107IUD(String iudGubun, Ifs7107 inifs7107) {
        try {
            Double pk = inifs7107.getSeq();
            if (iudGubun.equals("D")) {
                if (!ifs7107Repository.deleteIfs7107(inifs7107.getHospCode(), inifs7107.getFkifs7101(), inifs7107.getSeqRp(),
                        inifs7107.getSeqRpDrg(), inifs7107.getSeq())) {
                    return -1D;
                }
            } else if (iudGubun.equals("IR")) {
                return insertIfs7107(inifs7107);
            } else if (iudGubun.equals("U-")) {
                if (!ifs7107Repository.deleteIfs7107(inifs7107.getHospCode(), inifs7107.getFkifs7101(), inifs7107.getSeqRp(),
                        inifs7107.getSeqRpDrg(), inifs7107.getSeq())) {
                    return -1D;
                }
                return insertIfs7107(inifs7107);
            } else if (iudGubun.equals("I")) {
                String seqkey = inifs7107.getHospCode() + StringUtils.leftPad(String.format("%.0f", inifs7107.getFkifs7101()), 10, "0")
                        + StringUtils.leftPad(String.format("%.0f", inifs7107.getSeqRp()), 10, "0") + StringUtils.leftPad(String.format("%.0f", inifs7107.getSeqRpDrg()), 10, "0");
                Double seq = ifs7107Repository.getMaxSeq(inifs7107.getHospCode(), seqkey);
                inifs7107.setSeqRpDrg(seq);
                return insertIfs7107(inifs7107);
            }
            return pk;
        } catch (Exception e) {
            LOG.error(e.getMessage(), e);
            return -1D;
        }
    }

    public Double insertIfs7107(Ifs7107 inIfs7107) {
        try {
            ifs7107Repository.save(inIfs7107);
            return inIfs7107.getSeq();
        } catch (Exception e) {
            LOG.error(e.getMessage(), e);
            return -1D;
        }
    }

    /**
     * Migrate PROCEDURE FROM_DRG_TO_IFS7101 to java
     *
     * @param drg5100p01CurDrgOrderInfo
     * @return
     */
    public Ifs7101 fromDrgToIfs7101(DrgsDRG5100P01CurDrgOrderInfo drg5100p01CurDrgOrderInfo) {
        Ifs7101 ifs7101 = new Ifs7101();

        ifs7101.setSysId("IF");
        ifs7101.setSysDate(new Date());
        ifs7101.setHospCode(drg5100p01CurDrgOrderInfo.getHospCode());
        ifs7101.setRecGubun(ifsPad7101("REC_GUBUN", "VARCHAR", "S1"));
        ifs7101.setEndFlag(ifsPad7101("END_FLAG", "VARCHAR", " "));

        ifs7101.setIoGubun(ifsPad7101("IO_GUBUN", "VARCHAR", drg5100p01CurDrgOrderInfo.getIoGubun()));
        ifs7101.setDrgOrdGubun(ifsPad7101("DRG_ORD_GUBUN", "VARCHAR", drg5100p01CurDrgOrderInfo.getDrgOrdGubun()));
        ifs7101.setIpToiwonGubun(ifsPad7101("IP_TOIWON_GUBUN", "VARCHAR", drg5100p01CurDrgOrderInfo.getIpToiwonGubun()));
        ifs7101.setDataGubun(ifsPad7101("DATA_GUBUN", "VARCHAR", drg5100p01CurDrgOrderInfo.getDataGubun()));

        ifs7101.setJubsuBunho(ifsPad7101("JUBSU_BUNHO", "NUMBER", String.format("%.0f", drg5100p01CurDrgOrderInfo.getDrgBunho())));
        ifs7101.setSendDate(ifsPad7101("SEND_DATE", "NUMBER", DateUtil.getCurrentDateTime(DateUtil.PATTERN_YYMMDD_BLANK)));
        ifs7101.setSendTime(ifsPad7101("SEND_TIME", "NUMBER", DateUtil.getCurrentHH24MI()));

        ifs7101.setJojeDate(ifsPad7101("JOJE_DATE", "NUMBER", DateUtil.toString(drg5100p01CurDrgOrderInfo.getJojeDate(), DateUtil.PATTERN_YYMMDD_BLANK)));
        ifs7101.setBogyongStartDate(ifsPad7101("BOGYONG_START_DATE", "NUMBER", DateUtil.toString(drg5100p01CurDrgOrderInfo.getBogyongStartDate(), DateUtil.PATTERN_YYMMDD_BLANK)));

        ifs7101.setHoDong(ifsPad7101("HO_DONG", "VARCHAR", drg5100p01CurDrgOrderInfo.getHoDong()));
        ifs7101.setHoDongName(ifsPad7101("HO_DONG_NAME", "VARCHAR", drg5100p01CurDrgOrderInfo.getHoDongName()));
        ifs7101.setGwa(ifsPad7101("GWA", "VARCHAR", drg5100p01CurDrgOrderInfo.getGwa()));
        ifs7101.setGwaName(ifsPad7101("GWA_NAME", "VARCHAR", drg5100p01CurDrgOrderInfo.getGwaName()));
        ifs7101.setHoCode(ifsPad7101("HO_CODE", "VARCHAR", drg5100p01CurDrgOrderInfo.getHoCode()));
        ifs7101.setHoCodeName(ifsPad7101("HO_CODE_NAME", "VARCHAR", drg5100p01CurDrgOrderInfo.getHoCodeName()));
        ifs7101.setDoctor(ifsPad7101("DOCTOR", "VARCHAR", drg5100p01CurDrgOrderInfo.getDoctor()));
        ifs7101.setDoctorName(ifsPad7101("DOCTOR_NAME", "VARCHAR", drg5100p01CurDrgOrderInfo.getDoctorName()));

        ifs7101.setRpCnt(ifsPad7101("RP_CNT", "NUMBER", drg5100p01CurDrgOrderInfo.getRpCnt().toString()));
        ifs7101.setOrdCmtCnt(ifsPad7101("ORD_CMT_CNT", "NUMBER", drg5100p01CurDrgOrderInfo.getOrdCmtCnt().toString()));

        ifs7101.setDrgInfoPrtYn(ifsPad7101("DRG_INFO_PRT_YN", "VARCHAR", "0"));
        ifs7101.setDrgMybookPrtYn(ifsPad7101("DRG_MYBOOK_PRT_YN", "VARCHAR", "0"));
        ifs7101.setPrinterGubun(ifsPad7101("PRINTER_GUBUN", "NUMBER", "0"));
        ifs7101.setPrintGubun(ifsPad7101("PRINT_GUBUN", "NUMBER", "0"));
        ifs7101.setBaebunFlag(ifsPad7101("BAEBUN_FLAG", "VARCHAR", " "));
        ifs7101.setOrdResultCode(ifsPad7101("ORD_RESULT_CODE", "VARCHAR", " "));
        ifs7101.setOrdActYn(ifsPad7101("ORD_ACT_YN", "VARCHAR", " "));
        ifs7101.setOrdNoSrc(ifsPad7101("ORD_NO_SRC", "VARCHAR", " "));
        ifs7101.setRemark(ifsPad7101("REMARK", "VARCHAR", " "));

        ifs7101.setFkdrg4010(drg5100p01CurDrgOrderInfo.getFkdrg());
        ifs7101.setIfDate(new Date());
        ifs7101.setIfTime(DateUtil.getCurrentHH24MI());
        ifs7101.setIfFlag("10");
        ifs7101.setIfErr(null);

        return ifs7101;
    }

    /**
     * Migrate PROCEDURE FROM_DRG_TO_IFS7103 to java
     *
     * @param drg5100p01CurDrgOrderInfo
     * @param ifs7101
     * @return
     */
    public Ifs7103 fromDrgToIfs7103(DrgsDRG5100P01CurDrgOrderInfo drg5100p01CurDrgOrderInfo, Ifs7101 ifs7101) {
        Ifs7103 ifs7103 = new Ifs7103();
        ifs7103.setSysId("IF");
        ifs7103.setSysDate(new Date());
        ifs7103.setHospCode(drg5100p01CurDrgOrderInfo.getHospCode());
        ifs7103.setFkifs7101(ifs7101.getPkifs7101());

        ifs7103.setRecGubun(ifsPad7103("REC_GUBUN", "VARCHAR", "K1"));
        ifs7103.setEndFlag(ifsPad7103("END_FLAG", "VARCHAR", " "));

        ifs7103.setBunho(ifsPad7103("BUNHO", "VARCHAR", drg5100p01CurDrgOrderInfo.getBunho()));
        ifs7103.setName(ifsPad7103("NAME", "VARCHAR", drg5100p01CurDrgOrderInfo.getName()));
        ifs7103.setNameKana(ifsPad7103("NAME_KANA", "VARCHAR", drg5100p01CurDrgOrderInfo.getNameKana()));
        ifs7103.setSex(ifsPad7103("SEX", "VARCHAR", drg5100p01CurDrgOrderInfo.getSex()));
        ifs7103.setBirthday(ifsPad7103("BIRTHDAY", "NUMBER", DateUtil.toString(drg5100p01CurDrgOrderInfo.getBirthDay(), DateUtil.PATTERN_YYMMDD_BLANK)));

        ifs7103.setDrgPackYn(ifsPad7103("DRG_PACK_YN", "VARCHAR", drg5100p01CurDrgOrderInfo.getDrgPackYn()));
        ifs7103.setPowderYn(ifsPad7103("POWDER_YN", "VARCHAR", drg5100p01CurDrgOrderInfo.getPowderYn()));
        ifs7103.setRemark(ifsPad7103("REMARK", "VARCHAR", " "));

        return ifs7103;
    }

    /**
     * Migrate PROCEDURE FROM_DRG_TO_IFS7104 to java
     *
     * @param drg5100p01CurDrgOrderInfo
     * @param ifs7101
     * @return
     */
    public Ifs7104 fromDrgToIfs7104(DrgsDRG5100P01CurDrgOrderInfo drg5100p01CurDrgOrderInfo, Ifs7101 ifs7101) {
        Ifs7104 ifs7104 = new Ifs7104();
        ifs7104.setSysId("IF");
        ifs7104.setSysDate(new Date());
        ifs7104.setHospCode(drg5100p01CurDrgOrderInfo.getHospCode());
        ifs7104.setFkifs7101(ifs7101.getPkifs7101());

        ifs7104.setRecGubun(ifsPad7104("REC_GUBUN", "VARCHAR", "Y1"));
        ifs7104.setEndFlag(ifsPad7104("END_FLAG", "VARCHAR", " "));

        ifs7104.setDrgRpNo(ifsPad7104("DRG_RP_NO", "NUMBER", drg5100p01CurDrgOrderInfo.getDrgRpNo()));
        ifs7104.setDrgCnt(ifsPad7104("DRG_CNT", "NUMBER", drg5100p01CurDrgOrderInfo.getDrgCnt()));
        ifs7104.setDrgRpCmtCnt(ifsPad7104("DRG_RP_CMT_CNT", "NUMBER", "0"));

        ifs7104.setBogyongGubun(ifsPad7104("BOGYONG_GUBUN", "VARCHAR", drg5100p01CurDrgOrderInfo.getBogyongGubun()));
        ifs7104.setBogyongCode(ifsPad7104("BOGYONG_CODE", "VARCHAR", drg5100p01CurDrgOrderInfo.getBogyongCode()));
        ifs7104.setBogyongSigiGubun(ifsPad7104("BOGYONG_SIGI_GUBUN", "VARCHAR", drg5100p01CurDrgOrderInfo.getBogyongSigiGubun()));
        ifs7104.setBogyongSigi(ifsPad7104("BOGYONG_SIGI", "VARCHAR", drg5100p01CurDrgOrderInfo.getBogyongSigi()));
        ifs7104.setBogyongCodeName(ifsPad7104("BOGYONG_CODE_NAME", "VARCHAR", drg5100p01CurDrgOrderInfo.getBogyongName()));

        ifs7104.setDv(ifsPad7104("DV", "VARCHAR", drg5100p01CurDrgOrderInfo.getDv()));
        ifs7104.setDayDvGubun(ifsPad7104("DAY_DV_GUBUN", "VARCHAR", drg5100p01CurDrgOrderInfo.getDayDvGubun()));
        ifs7104.setDayDvCnt(ifsPad7104("DAY_DV_CNT", "VARCHAR", drg5100p01CurDrgOrderInfo.getDayDvCnt()));
        ifs7104.setDrgBunho(ifsPad7104("DRG_BUNHO", "VARCHAR", " "));
        ifs7104.setRemark1(ifsPad7104("REMARK1", "VARCHAR", " "));

        ifs7104.setGiganCnt(ifsPad7104("GIGAN_CNT", "VARCHAR", "0"));
        ifs7104.setGiganGubun(ifsPad7104("GIGAN_GUBUN", "VARCHAR", "0"));
        ifs7104.setWeekDays(ifsPad7104("WEEK_DAYS", "VARCHAR", "1111111"));
        ifs7104.setRemark(ifsPad7104("REMARK", "VARCHAR", " "));

        return ifs7104;
    }

    public Ifs7106 fromDrgToIfs7106(DrgsDRG5100P01CurDrgOrderInfo drg5100p01CurDrgOrderInfo, Ifs7104 ifs7104) {
        int patternSeq = 0;
        Ifs7106 ifs7106 = new Ifs7106();
        ifs7106.setSysId("IF");
        ifs7106.setSysDate(new Date());
        ifs7106.setHospCode(drg5100p01CurDrgOrderInfo.getHospCode());
        ifs7106.setFkifs7101(ifs7104.getFkifs7101());
        ifs7106.setSeqRp(ifs7104.getSeqRp());

        ifs7106.setRecGubun(ifsPad7106("REC_GUBUN", "VARCHAR", "D1"));
        ifs7106.setEndFlag(ifsPad7106("END_FLAG", "VARCHAR", " "));

        ifs7106.setDrgSeq(ifsPad7106("DRG_SEQ", "NUMBER", drg5100p01CurDrgOrderInfo.getDrgSeq().toString()));
        ifs7106.setDrgCmtCnt(ifsPad7106("DRG_CMT_CNT", "NUMBER", drg5100p01CurDrgOrderInfo.getDrgCmtCnt().toString()));

        ifs7106.setDrgCodeHu(ifsPad7106("DRG_CODE_HU", "VARCHAR", drg5100p01CurDrgOrderInfo.getDrgCode()));
        ifs7106.setDrgCode(ifsPad7106("DRG_CODE", "VARCHAR", drg5100p01CurDrgOrderInfo.getDrgCode()));
        ifs7106.setDrgCodeNameKana(ifsPad7106("DRG_CODE_NAME_KANA", "VARCHAR", drg5100p01CurDrgOrderInfo.getDrgNameKana()));
        ifs7106.setDrgCodeName(ifsPad7106("DRG_CODE_NAME", "VARCHAR", drg5100p01CurDrgOrderInfo.getDrgName()));
        ifs7106.setDrgGubun(ifsPad7106("DRG_GUBUN", "VARCHAR", drg5100p01CurDrgOrderInfo.getDrgGubun()));
        ifs7106.setDrgType(ifsPad7106("DRG_TYPE", "VARCHAR", drg5100p01CurDrgOrderInfo.getDrgType()));
        ifs7106.setDanui(ifsPad7106("DANUI", "VARCHAR", drg5100p01CurDrgOrderInfo.getDanui()));
        ifs7106.setDanuiName(ifsPad7106("DANUI_NAME", "VARCHAR", drg5100p01CurDrgOrderInfo.getDanuiName()));

        ifs7106.setSuryang(ifsPad7106("SURYANG", "VARCHAR", String.format("%.0f", drg5100p01CurDrgOrderInfo.getSuryang())));
        ifs7106.setUnbalanceYn(ifsPad7106("UNBALANCE_YN", "VARCHAR", drg5100p01CurDrgOrderInfo.getUnbalanceYn()));

        String pattern = drg5100p01CurDrgOrderInfo.getPattern().substring(1, 7);
        int lengthPattern = pattern.length();
        for (int patternPos = 0; patternPos < lengthPattern; patternPos++) {
            if (pattern.substring(patternPos, patternPos + 1).equals("1")) {
                patternSeq = patternSeq + 1;
                ifs7106 = loadUnbalanceDv(patternSeq, patternPos, drg5100p01CurDrgOrderInfo, ifs7106);
            }
        }

        ifs7106.setUnbalance1(ifsPad7106("UNBALANCE_1", "VARCHAR", ifs7106.getUnbalance1()));
        ifs7106.setUnbalance2(ifsPad7106("UNBALANCE_2", "VARCHAR", ifs7106.getUnbalance2()));
        ifs7106.setUnbalance3(ifsPad7106("UNBALANCE_3", "VARCHAR", ifs7106.getUnbalance3()));
        ifs7106.setUnbalance4(ifsPad7106("UNBALANCE_4", "VARCHAR", ifs7106.getUnbalance4()));
        ifs7106.setUnbalance5(ifsPad7106("UNBALANCE_5", "VARCHAR", ifs7106.getUnbalance5()));
        ifs7106.setUnbalanceX(ifsPad7106("UNBALANCE_X", "VARCHAR", ifs7106.getUnbalanceX()));

        ifs7106.setPowderYn(ifsPad7106("POWDER_YN", "VARCHAR", drg5100p01CurDrgOrderInfo.getPowderYn()));
        ifs7106.setDrgPackYn(ifsPad7106("DRG_PACK_YN", "VARCHAR", drg5100p01CurDrgOrderInfo.getDrgPackYn()));

        ifs7106.setDrgBunho(ifsPad7106("DRG_BUNHO", "VARCHAR", " "));
        ifs7106.setMstInfo1(ifsPad7106("MST_INFO_1", "VARCHAR", " "));
        ifs7106.setMstInfo2(ifsPad7106("MST_INFO_2", "VARCHAR", " "));
        ifs7106.setMstInfo3(ifsPad7106("MST_INFO_3", "VARCHAR", " "));
        ifs7106.setMstInfo4(ifsPad7106("MST_INFO_4", "VARCHAR", " "));
        ifs7106.setMstInfo5(ifsPad7106("MST_INFO_5", "VARCHAR", " "));
        ifs7106.setMstInfo6(ifsPad7106("MST_INFO_6", "VARCHAR", " "));

        ifs7106.setBogyongStartDate(ifsPad7106("MST_INFO_6", "BOGYONG_START_DATE", DateUtil.toString(drg5100p01CurDrgOrderInfo.getBogyongStartDate(), DateUtil.PATTERN_YYMMDD_BLANK)));
        ifs7106.setRemark(ifsPad7106("MST_INFO_6", "REMARK", " "));

        return ifs7106;
    }

    /**
     * Migrate PROCEDURE DRG_MASTER_INSERT to java
     *
     * @param hospCode
     * @param jubsuDate
     * @param drgBunho
     * @param dataDubun
     * @param inOutGubun
     * @param bunho
     * @param fk
     * @return
     */
    public Double drgMasterInsert(String hospCode, Date jubsuDate, Double drgBunho, String dataDubun, String inOutGubun, String bunho,
                                  Double fk) {
        try {
            Double outPk = null;

            Drg4010 drg4010 = new Drg4010();
            drg4010.setSysId("IF");
            drg4010.setSysDate(new Date());
            drg4010.setUpdId(null);
            drg4010.setUpdDate(null);
            drg4010.setHospCode(hospCode);

            drg4010.setJubsuDate(jubsuDate);
            drg4010.setDrgBunho(drgBunho);

            drg4010.setDataDubun(dataDubun);
            drg4010.setInOutGubun(inOutGubun);
            drg4010.setBunho(bunho);

            if (drg4010.getInOutGubun().equals("O")) {
                drg4010.setFkout1001(fk);
            } else {
                drg4010.setFkinp1001(fk);
            }

            drg4010.setIfSendFlag("N");
            outPk = drg4010IUD("I", drg4010);
            return outPk;
        } catch (Exception e) {
            LOG.error(e.getMessage(), e);
            return -1D;
        }
    }

    public DrgsDRG5100P01DrgMasterInsertResponseInfo drgProcMain(String hospCode, String ioGubun, Double masterPk, String sendYn, String hospitalCode, String language) {
        DrgsDRG5100P01DrgMasterInsertResponseInfo outProc = new DrgsDRG5100P01DrgMasterInsertResponseInfo();
        try {

            Ifs7101 R1 = new Ifs7101();
            Ifs7102 R2 = new Ifs7102();
            Ifs7103 R3 = new Ifs7103();
            Ifs7104 R4 = new Ifs7104();
            Ifs7106 R6 = new Ifs7106();
            Ifs7107 R7 = new Ifs7107();

            String comment;
            int mCnt = 0;
            int mDrgSeq = 0;
            if (sendYn.equals("Y")) {
                List<DrgsDRG5100P01CurDrgOrderInfo> listResult = null;
                if (ioGubun.equals("O")) {
                    listResult = drg2010Repository.getDrgsDRG5100P01CurDrgOrderInfo(hospitalCode, language,
                            masterPk, ioGubun);
                } else if (ioGubun.equals("I")) {
                    listResult = drg3010Repository.getDrgsDRG5100P01CurDrgOrderInfo(hospitalCode, language,
                            masterPk, ioGubun);
                }
                if (!CollectionUtils.isEmpty(listResult)) {
                    for (DrgsDRG5100P01CurDrgOrderInfo R0 : listResult) {
                        if (((R0.getDrgBunho() == null) ? -1D : R0.getDrgBunho()) != 0D) {
                            R1 = fromDrgToIfs7101(R0);
                            R1.setPkifs7101(ifs7101IUD("I", R1));

                            R2.setSysId(R1.getSysId());
                            R2.setSysDate(R1.getSysDate());
                            R2.setHospCode(R1.getHospCode());
                            R2.setFkifs7101(R1.getPkifs7101());

                            R2.setRecGubun(ifsPad7102("REC_GUBUN", "VARCHAR", "S2"));
                            R2.setEndFlag(ifsPad7102("END_FLAG", "VARCHAR", " "));
                            R2.setOrdCmtCode(ifsPad7102("ORD_CMT_CODE", "VARCHAR", " "));

                            R2.setRemark(ifsPad7102("REMARK", "VARCHAR", " "));
                            if (R0.getOrdCmt() != null && R0.getOrdCmt().intValue() > 0) {
                                for (int i = 1; i <= R0.getOrdCmt().intValue(); i++) {
                                    comment = R0.getOrdCmt().toString().substring((i - 1) * 50 + 1, 50);
                                    R2.setOrdCmtCodeName(ifsPad7102("ORD_CMT_CODE_NAME", "VARCHAR", comment));
                                    ifs7102UID("I", R2);
                                }
                            }
                            R3 = fromDrgToIfs7103(R0, R1);
                            ifs7103IUD("I", R3);
                        }

                        if (((R0.getDrgRpNo() == null) ? "-1" : R0.getDrgRpNo()) != "0") {
                            mCnt = mCnt + 1;
                            R4 = fromDrgToIfs7104(R0, R1);
                            R4.setSeqRp(ifs7104IUD("I", R4));

                            mDrgSeq = 0;
                        }

                        mDrgSeq = mDrgSeq + 1;
                        R0.setDrgSeq(BigInteger.valueOf(mDrgSeq));

                        R6 = fromDrgToIfs7106(R0, R4);

                        R6.setSeqRpDrg(ifs7106IUD("I", R6));

                        R7.setSysId(R6.getSysId());
                        R7.setSysDate(R6.getSysDate());
                        R7.setHospCode(R6.getHospCode());
                        R7.setFkifs7101(R6.getFkifs7101());
                        R7.setSeqRp(R6.getSeqRp());
                        R7.setSeqRpDrg(R6.getSeqRpDrg());
                        R7.setRecGubun(ifsPad7107("REC_GUBUN", "VARCHAR", "D2"));
                        R7.setEndFlag(ifsPad7107("END_FLAG", "VARCHAR", " "));
                        R7.setDrgCmtCode(ifsPad7107("DRG_CMT_CODE", "VARCHAR", " "));
                        R7.setDrgCmtGubun(ifsPad7107("DRG_CMT_GUBUN", "VARCHAR", "0"));
                        R7.setRemark(ifsPad7107("REMARK", "VARCHAR", " "));
                        if (R0.getDrgCmtCnt() != null && R0.getDrgCmtCnt().intValue() > 0) {
                            for (int i = 1; i <= R0.getDrgCmtCnt().intValue(); i++) {
                                comment = R0.getDrgCmtCnt().toString().substring((i - 1) * 50 + 1, 50);
                                R7.setDrgCmtCodeName(ifsPad7102("DRG_CMT_CODE_NAME", "VARCHAR", comment));
                                R7.setSeq(ifs7102UID("I", R2));
                            }
                        }
                    }

                    String endFlag = ifsPad7107("END_FLAG", "VARCHAR", "E");
                    if (ifs7107Repository.updateIfs7107(endFlag, R7.getHospCode(), R7.getFkifs7101(), R7.getSeqRp(),
                            R7.getSeqRpDrg(), R7.getSeq()) <= 0) {
                        ifs7106Repository.updateIfs7106(endFlag, R6.getHospCode(), R6.getFkifs7101(), R6.getSeqRp(), R6.getSeqRpDrg());
                    }
                }
            } else if (sendYn.equals("N") || sendYn.equals("R")) {
                return null;
            }
            outProc.setoFlag("1");
            outProc.setoCnt(mCnt);

            return outProc;
        } catch (Exception e) {
            LOG.error(e.getMessage(), e);
            outProc.setoFlag("E");
            outProc.setoMsg(e.getMessage());
            return outProc;
        }
    }
}

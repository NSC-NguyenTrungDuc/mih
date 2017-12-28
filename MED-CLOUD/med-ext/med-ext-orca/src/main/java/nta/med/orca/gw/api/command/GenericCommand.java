package nta.med.orca.gw.api.command;

import nta.med.common.glossary.Lifecycle;

/**
 * @author dainguyen.
 */
//public interface GenericCommand<REQ, RES> extends Lifecycle {
public interface GenericCommand<REQ, RES> {

    RES execute(REQ request) throws Exception;

}
